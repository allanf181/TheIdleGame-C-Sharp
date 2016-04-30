using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;

namespace TheGame
{
    public partial class Form1 : Form
    {
        double dinheiro = 0;
        double valor = 1;
        double custo = 50;
        double custo_escravo = 1000;
        double custo_escravo_tempo = 5000;
        double dinheiro_escravo = 0.1;
        double custo_escravo_dinheiro = 3000;
        int tempo_escravo = 1000;
        double limite = 30000000000000;
        bool ativado = false;
        public Form1()
        {
            InitializeComponent();
            timer1.Start();
            // When window state changed, trigger state update.
            this.Resize += SetMinimizeState;

            // When tray icon clicked, trigger window state change.       
            notifyIcon1.MouseDoubleClick += ToggleMinimizeState;
            EnableTab(tabPage4, false);
            tabPage4.Text = "Futuro...";
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            dinheiro = dinheiro + (1 * valor);
            update();
        }

        private void button2_MouseClick(object sender, MouseEventArgs e)
        {
            dinheiro = dinheiro - custo;
            custo = custo * 3.5;
            label2.Text = "$: " + custo;
            update();
            valor = valor * 2;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (dinheiro < custo)
            {
                button2.Enabled = false;
            }
            else
            {
                button2.Enabled = true;
            }

            if (dinheiro < custo_escravo)
            {
                button3.Enabled = false;
            }
            else
            {
                button3.Enabled = true;
            }

            if (dinheiro < custo_escravo_tempo || tempo_escravo == 10)
            {
                button4.Enabled = false;
            }
            else
            {
                button4.Enabled = true;
            }

            if (dinheiro < custo_escravo_dinheiro)
            {
                button5.Enabled = false;
            }
            else
            {
                button5.Enabled = true;
            }

            if (dinheiro > limite && ativado == false)
            {
                EnableTab(tabPage4, true);
                tabPage4.Text = "Debug";
                ativado = true;
            }

            if (timer2.Enabled == true)
            {
                label10.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                label10.ForeColor = System.Drawing.Color.Red;
            }
        }
        // Toggle state between Normal and Minimized.
        private void ToggleMinimizeState(object sender, EventArgs e)
        {
            bool isMinimized = this.WindowState == FormWindowState.Minimized;
            this.WindowState = (isMinimized) ? FormWindowState.Normal : FormWindowState.Minimized;
        }

        // Show/Hide window and tray icon to match window state.
        private void SetMinimizeState(object sender, EventArgs e)
        {
            bool isMinimized = this.WindowState == FormWindowState.Minimized;

            this.ShowInTaskbar = !isMinimized;
            notifyIcon1.Visible = isMinimized;
            if (isMinimized) notifyIcon1.ShowBalloonTip(500, "The Idle Game", "Jogo minimizado e escondido.", ToolTipIcon.Info);
        }

        private void button3_MouseClick(object sender, MouseEventArgs e)
        {
            dinheiro = dinheiro - custo_escravo;
            update();
            button3.Visible = false;
            progressBar1.Visible = true;
            label3.Visible = false;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            label7.Visible = true;
            button4.Visible = true;
            button5.Visible = true;
            timer2.Start();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            progressBar1.PerformStep();
            progressBar1.PerformStep();
            progressBar1.PerformStep();
            progressBar1.PerformStep();
            progressBar1.PerformStep();
            progressBar1.PerformStep();
            progressBar1.PerformStep();
            progressBar1.PerformStep();
            progressBar1.PerformStep();
            progressBar1.PerformStep();
            dinheiro = dinheiro + dinheiro_escravo;
            update();
        }

        private void buttonD_Click(object sender, EventArgs e)
        {
            dinheiro = double.Parse(textBoxD.Text);
            update();
        }

        private void update()
        {
            label1.Text = string.Format("$: {0:N2}",dinheiro);
        }

        private void button4_MouseClick(object sender, MouseEventArgs e)
        {
            dinheiro = dinheiro - custo_escravo_tempo;
            tempo_escravo = tempo_escravo - 10;
            timer2.Interval = tempo_escravo;
            custo_escravo_tempo = custo_escravo_tempo * 5;
            label6.Text = "$ " + custo_escravo_tempo;
            label4.Text = "Tempo: " + tempo_escravo + "ms";
        }

        private void button5_MouseClick(object sender, MouseEventArgs e)
        {
            dinheiro = dinheiro - custo_escravo_dinheiro;
            custo_escravo_dinheiro = custo_escravo_dinheiro * 4;
            dinheiro_escravo = dinheiro_escravo * 2;
            label7.Text = "$: " + custo_escravo_dinheiro;
            label5.Text = "Geração: $ " + dinheiro_escravo;
        }
        public static void EnableTab(TabPage page, bool enable)
        {
            foreach (Control ctl in page.Controls) ctl.Visible = enable;
        }


        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            /*Cheats desativados
            if (e.KeyCode == Keys.Oemplus && (e.Control && e.Alt))
            {
                EnableTab(tabPage4, true);
                tabPage4.Text = "test";
            }

            if (e.KeyCode == Keys.OemMinus && (e.Control && e.Alt))
            {
                EnableTab(tabPage4, false);
                tabPage4.Text = "test";
            }*/
        }

        private void button6_MouseClick(object sender, MouseEventArgs e)
        {
            timer2.Start();
        }

        private void button7_MouseClick(object sender, MouseEventArgs e)
        {
            timer2.Stop();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            Process.Start("http://allanf181.github.io/");
        }

    }
}
