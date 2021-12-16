using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using Microsoft.AspNetCore.SignalR.Client;
using PingPong3.Patterns.CompositeInterpreter;

namespace PingPong3.Forms
{
    public partial class DevConsole : Form
    {
        HubConnection connection;
        Lexer lexer;
        Parser parser;
        Interpreter interpreter;
        public DevConsole()
        {
            InitializeComponent();
            connection = new HubConnectionBuilder()
                .WithUrl("http://localhost:53353/ChatHub")
                .Build();
            connection.Closed += async (error) =>
            {
                await Task.Delay(new Random().Next(0, 5) * 1000);
                await connection.StartAsync();
            };
            InitializeConnection();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.Enter) && textBox1.Text != "")
            {
                Run();
            }
        }
        public void Run()
        {
            lexer = new Lexer(textBox1.Text + '\n');
            PrintLine(textBox1.Text);
            textBox1.Text = "";
            LexResult lexResult = lexer.make_tokens();
            if(lexResult.error != null)
            {
                PrintLine(lexResult.error.ToString());
                return;
            }
            parser = new Parser(lexResult.tokens);
            ParseResult parseResult = parser.parse();
            if (parseResult.error != null)
            {
                PrintLine(parseResult.error.ToString());
                return;
            }
            interpreter = new Interpreter(connection);
            InterpretResult interpretResult = interpreter.interpret(parseResult.node);
            if(interpretResult.error != null)
            {
                PrintLine(interpretResult.error.ToString());
                return;
            }
            PrintLine(interpretResult.value.value.ToString());
        }
        private void PrintLine(String s)
        {
            richTextBox1.Text = richTextBox1.Text + s + '\n';
        }
        private void Print(String s)
        {
            richTextBox1.Text = richTextBox1.Text + s;
        }
        private async void InitializeConnection()
        {
            try
            {
                await connection.StartAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            richTextBox1.SelectionStart = richTextBox1.Text.Length;
            richTextBox1.ScrollToCaret();
        }
    }
}
