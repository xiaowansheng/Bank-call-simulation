using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Bank : Form
    {
        public static int MAX = 500;
        //接待总人数
        int i = 0;
        //号码数
        int n = 0;
        Queue<int> queue = new Queue<int>(500);
        int[] resolve = new int[5];
        public Bank()
        {
            InitializeComponent();
            leaves.Text = "";
            please.Text = "";
            get.Text = "";
        }

        public void help(Label label,int number)
        {
            if (label.Text != "空")
            {
                MessageBox.Show("当前窗口已经有用户在办理业务，请稍等在试试！");
                return;
            }
            if (queue.Count > 0)
            {
                int client = queue.Dequeue();
                please.Text = "请" + client + "号客户到"+number+"号窗口办理业务";
                label.Text = client + "号客户";
                tips.Text = String.Format("总接待人数：{0}", i);
                wait.Text = String.Format("提示：当前的排队人数：{0}", queue.Count);
                resolve[number] = 1;
            }
            else
            {
                MessageBox.Show("当前已经没有人需要办理业务，请稍等在试试！");
            }
        }

        public void leave(Label label,int number)
        {
            if (label.Text != "空")
            {
                leaves.Text = label.Text + "已离开。";
                label.Text = "空";
                i++;
                tips.Text = "提示：总接待人数：" + i;
                resolve[number] = 0;
            }
        }


        private void getnumber_Click(object sender, EventArgs e)
        {
            if (i <= MAX)
            {
                n++;
                queue.Enqueue(n);
                get.Text = "您当前取出的号码为：" + n;
                tips.Text = String.Format("总接待人数：{0}", i);
                wait.Text = String.Format("当前的排队人数：{0}",queue.Count);
            }
            else
            {
                MessageBox.Show("今日办理业务已结束，请明日再来办理！");
            }
        }

        private void next1_Click(object sender, EventArgs e)
        {
            help(r1, 0);
        }

        private void next2_Click(object sender, EventArgs e)
        {
            help(r2, 1);
        }

        private void next3_Click(object sender, EventArgs e)
        {

            help(r3, 2);
        }

        private void next4_Click(object sender, EventArgs e)
        {
            help(r4, 3);
        }

        private void next5_Click(object sender, EventArgs e)
        {
            help(r5,4);
        }

        private void leave3_Click(object sender, EventArgs e)
        {

            leave(r3,2);
        }

        private void leave2_Click(object sender, EventArgs e)
        {

            leave(r2,1);
        }

        private void leave1_Click(object sender, EventArgs e)
        {
            leave(r1,0);
        }

        private void leave4_Click(object sender, EventArgs e)
        {

            leave(r4,3);
        }

        private void leave5_Click(object sender, EventArgs e)
        {

            leave(r5,4);
        }

    }
}
