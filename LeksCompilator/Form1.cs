using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace LeksCompilator
{
    public partial class Form1 : Form
    {
        List<string> inputExprText = new List<string>();
        List<Expres> expresList = new List<Expres>();
        string inputText = "";
        int counterExpr = 0;
        Dictionary<string, string> symbols = new Dictionary<string, string>();
        public Form1()
        {
            InitializeComponent();
            Expres.textbox = textTxt;
            Expres.errorbox = errorsTxt;
        }
        public bool getText()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Текстовые файлы|*.txt";
            openFileDialog.Title = "Выберите текстовый файл";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    inputText = File.ReadAllText(openFileDialog.FileName, Encoding.GetEncoding(1251));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(string.Format("Ошибка при загрузке файла: {0}", ex.Message));
                }
            }
            else
            {
                MessageBox.Show("Неизвестная ошибка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void loadBtn_Click(object sender, EventArgs e)
        {
            counterExpr = 0;
            prevExprBtn.Enabled = false;
            nextExprBtn.Enabled = false;
            expressionTxt.Text = "";
            textTxt.Text = "";
            errorsTxt.Text = "";
            leksemsTable.Rows.Clear();
            if (!getText())
                return;
            if (inputText.Length == 0)
            {
                MessageBox.Show("Файл пуст");
                return;
            }
            textTxt.Text = inputText;
            FindExpressions();
            if (inputExprText.Count > 1)
            {
                nextExprBtn.Enabled = true;
            }
            if (inputExprText.Count == 0)
            {
                errorsTxt.Text += "Ошибка: Ожидался разделитель выражений (;)" + Environment.NewLine;
                return;
            }
            string expr = inputExprText[counterExpr];
            expressionTxt.Text = expr;
            Expres.fullText = textTxt.Text;
            Expres.countn = new Regex(@"\n").Matches(textTxt.Text).Count;
            makeExpress();
            outTable();
        }
        public void makeExpress()
        {
            expresList.Clear();
            FindExpressions();
            if (String.IsNullOrEmpty(inputText) || String.IsNullOrWhiteSpace(inputText))
            {
                MessageBox.Show("Исходный текст пуст");
                return;
            }
            foreach (string express in inputExprText)
            {
                Expres expres = new Expres(express);
                expresList.Add(expres);
            }
            expresList[counterExpr].leksOut(leksemsTable);
        }
        public void FindExpressions()
        {
            inputExprText.Clear();
            Regex pattern = new Regex(@"(/\*([^*]|[\r\n]|(\*+([^*/]|[\r\n])))*\*+/)|(//.*)", RegexOptions.Singleline);
            foreach (Match str in pattern.Matches(inputText))
            {
                inputText = inputText.Replace(str.Value, "");
            }
            pattern = new Regex(".*?;", RegexOptions.Singleline);
            foreach(Match str in pattern.Matches(inputText))
            {
                string m = str.Value.Replace(Environment.NewLine, "");
                inputExprText.Add(m);
            }
            //pattern = new Regex(";.*?[^;]$", RegexOptions.Singleline);
            //inputExprText.Add(pattern.Match(inputText).Value);
        }
        public void outTable()
        {
            mergeTables();
            using (StreamWriter writer = new StreamWriter("../../TablesOutput/identifierTable.txt"))
            {
                double result;
                foreach (KeyValuePair<string, string> pair in symbols)
                {
                    double.TryParse(pair.Key, out result);
                    writer.WriteLine("{0,-32} - {1,-32} - {2}", pair.Key, pair.Value, result);
                }
            }
        }
        public void mergeTables()
        {
            foreach (Expres expr in expresList)
            {
                foreach (KeyValuePair<string, string> dict in expr.leksems)
                {
                    if (!symbols.ContainsKey(dict.Key))
                    {
                        symbols.Add(dict.Key, dict.Value);
                    }
                }
            }
        }
        private void nextExprBtn_Click(object sender, EventArgs e)
        {
            if (inputExprText.Count == 0 || String.IsNullOrEmpty(inputExprText[counterExpr + 1]))
            {
                MessageBox.Show("Выражений нет");
                return;
            }
            counterExpr++;
            expressionTxt.Text = inputExprText[counterExpr];
            if (counterExpr + 2 > inputExprText.Count)
            {
                nextExprBtn.Enabled = false;
            }
            prevExprBtn.Enabled = true;
            expresList[counterExpr].leksOut(leksemsTable);
        }
        private void prevExprBtn_Click(object sender, EventArgs e)
        {
            if (inputExprText.Count == 0 || String.IsNullOrEmpty(inputExprText[counterExpr - 1]))
            {
                MessageBox.Show("Выражений нет");
                return;
            }
            counterExpr--;
            expressionTxt.Text = inputExprText[counterExpr];
            if (counterExpr - 1 < 0)
            {
                prevExprBtn.Enabled = false;
            }
            nextExprBtn.Enabled = true;
            expresList[counterExpr].leksOut(leksemsTable);
        }
        private void inputStringTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
