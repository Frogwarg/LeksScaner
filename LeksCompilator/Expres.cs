﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace LeksCompilator
{
    internal class Expres
    {
        public Dictionary<string, string> leksems= new Dictionary<string, string>();
        public static RichTextBox textbox;
        public static RichTextBox errorbox;
        public static string fullText = "";
        public int position;
        string exp = "";
        public static int countn;

        private static Regex IdentifierRegex = new Regex(@"^[a-zA-Z_][a-zA-Z0-9_]*$");
        private static Regex OperatorRegex = new Regex(@"^[\+\-\*\/]$");
        private static Regex BracketsRegex = new Regex(@"^[\(\)]$");
        private static Regex AssignmentRegex = new Regex(@"^:=$");
        private static Regex EndRegex = new Regex(@"^;$");
        public Expres() { }
        public Expres(string expression)
        {
            this.exp = expression;
            Scan(expression);
        }
        private void Scan(string expression)
        {
            fullText= fullText.Replace("\n", "");
            position = fullText.IndexOf(expression);
            MatchCollection matches= new Regex(@"[\w\,]+|:=|\+|-|\*|/|\(|\)|;").Matches(expression);
            string[] opers = new string[] { "+", "-", "/", "*" };
            foreach (Match match in matches)
            {
                if (match.Success && !leksems.Keys.Contains(match.Value))
                {
                    if (match.Value == ":=")
                    {
                        leksems.Add(match.Value, "Знак присваивания");
                        continue;
                    }
                    if (opers.Contains<string>(match.Value)){
                        leksems.Add(match.Value, "Базовая арифметическая операция");
                        continue;
                    }
                    double result;
                    if (double.TryParse(match.Value, out result) && match.Value.Contains(","))
                    {
                        leksems.Add(match.Value, "Константа");
                        continue;
                    }
                    if (new Regex(@"[-+]?\d*\.?\d+([eE][-+]?\d+)?").Match(match.Value).Success)
                    {
                        leksems.Add(match.Value, "Константа");
                        continue;
                    }
                    if (match.Value ==")" || match.Value == "(")
                    {
                        leksems.Add(match.Value, "Скобка");
                        continue;
                    }
                    if (match.Value == ";")
                    {
                        leksems.Add(match.Value, "Конец выражения");
                        continue;
                    }
                    if (Regex.IsMatch(match.Value, @"^[_a-zA-Z][_a-zA-Z0-9]*$"))
                    {
                        leksems.Add(match.Value, "Идентификатор");
                        if (match.Value.Length > 32)
                        {
                            textbox.Select(position + expression.IndexOf(match.Value) + countn, match.Value.Length);
                            textbox.SelectionBackColor = Color.Red;
                            errorbox.Text += $"Ошибка: Длина идентификатора больше 32 символов" + Environment.NewLine;
                        }
                        continue;
                    }
                }
            }
            Validate(expression);
        }
        private void  Validate(string expression)
        {
            MatchCollection matches = new Regex(@"[\w\,]+|:=|\+|-|\*|/|\(|\)").Matches(expression);
            List<string> parts=new List<string>();
            var stack = new Stack<char>();
            string lastPart = null;
            foreach (Match match in matches)
            {
                parts.Add(match.Value);
                if (match.Value.Contains(":=") && lastPart != null && !IdentifierRegex.IsMatch(new Regex(@"^(.*)(?=:=)").Match(expression).Value))
                {
                    //MessageBox.Show(new Regex(@"^(.*)(?=:=)").Match(expression).Value);
                    textbox.Select(position + expression.IndexOf(new Regex(@"^(.*)(?=:=)").Match(expression).Value)+countn-1, new Regex(@"^(.*)(?=:=)").Match(expression).Value.Length);
                    textbox.SelectionBackColor = Color.Red;
                    errorbox.Text += $"Ошибка: Перед знаком присваивания должен быть только идентификатор" + Environment.NewLine;
                }
                if (lastPart != null)
                {
                    if ((IdentifierRegex.IsMatch(lastPart) && IdentifierRegex.IsMatch(match.Value)) ||
                        (OperatorRegex.IsMatch(lastPart) && OperatorRegex.IsMatch(match.Value)) ||
                        (AssignmentRegex.IsMatch(lastPart) && OperatorRegex.IsMatch(match.Value)))
                    {
                        textbox.Select(position + expression.IndexOf(lastPart), lastPart.Length+match.Value.Length);
                        textbox.SelectionBackColor = Color.Red;
                        errorbox.Text += $"Ошибка: Подряд идут несколько арифметических операторов или идентификаторов ({lastPart} {match.Value})" + Environment.NewLine;
                    }
                }
                double result;
                if (match.Value.Contains("(") && lastPart != null && (!double.TryParse(match.Value, out result) || !match.Value.Contains(",")) &&
                    !OperatorRegex.IsMatch(lastPart) && !lastPart.Contains(":=") && !lastPart.Contains("("))
                {
                    textbox.Select(position + expression.IndexOf(lastPart) + countn, lastPart.Length + match.Value.Length);
                    textbox.SelectionBackColor = Color.Red;
                    errorbox.Text += $"Ошибка: Перед скобкой нет знака операции" + Environment.NewLine;
                }
                lastPart = match.Value;
                if (match.Value.Contains("(")) 
                {
                    stack.Push('(');
                    continue;
                } 
                if (match.Value.Contains(")"))
                {
                    if (stack.Count == 0 || stack.Pop() != '(')
                    {
                        textbox.Select(position + expression.IndexOf(match.Value)+1 + countn, match.Value.Length);
                        textbox.SelectionBackColor = Color.Red;
                        errorbox.Text += $"Ошибка: Неправильное расположение скобок. Отсутствует открывающая скобка" + Environment.NewLine;
                        continue;
                    }
                }
                if (!IdentifierRegex.IsMatch(match.Value) && !OperatorRegex.IsMatch(match.Value) && !AssignmentRegex.IsMatch(match.Value) 
                    && !EndRegex.IsMatch(match.Value) && !BracketsRegex.IsMatch(match.Value) && (!double.TryParse(match.Value, out result) || !match.Value.Contains(",")))
                {
                    textbox.Select(position + expression.IndexOf(match.Value) + countn, match.Value.Length);
                    textbox.SelectionBackColor = Color.Red;
                    errorbox.Text += $"Ошибка: Неверный идентификатор или оператор '{match.Value}'" + Environment.NewLine;
                }
            }
            if (stack.Count > 0)
            {
                errorbox.Text += $"Ошибка: Неправильное расположение скобок. Отсутствует закрывающая скобка" + Environment.NewLine;
            }

            if (!leksems.ContainsKey(":="))
            {
                errorbox.Text += "Ошибка: Ожидался знак присваивания (:=)" + Environment.NewLine;
            } else
            {
                if (new Regex(@"(:=)").Matches(exp).Count > 1)
                {
                    textbox.SelectionBackColor = Color.White;
                    textbox.Select(position+expression.LastIndexOf(":=")+countn, 2);
                    textbox.SelectionBackColor = Color.Red;
                    errorbox.Text += $"Ошибка: Позиция {position+expression.LastIndexOf(":=")} Лишний знак присванивания (:=)" + Environment.NewLine;
                }
            }

        }
        public void leksOut(DataGridView table)
        {
            table.Rows.Clear();
            foreach (KeyValuePair<string, string> pair in leksems)
            {
                if (pair.Value== "Идентификатор" || pair.Value == "Конец выражения" || pair.Value == "Скобка" || pair.Value == "Базовая арифметическая операция" || pair.Value == "Знак присваивания")
                {
                    table.Rows.Add(pair.Key, pair.Value, "-");
                }else
                {
                    double result;
                    double.TryParse(pair.Key, out result);
                    table.Rows.Add(pair.Key, pair.Value, result);
                }
            }
        }
    }
}
