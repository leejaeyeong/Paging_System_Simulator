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

namespace _PagingSystem
{
    public partial class Form1 : Form
    {
        bool b_activeProceessA = false;     // 프로세스의 동작 여부
        bool b_activeProceessB = false;
        bool b_activeProceessC = false;
        bool b_activeProceessD = false;
        int A_pageCount;                    // 프로세스의 page 개수
        int B_pageCount;
        int C_pageCount;
        int D_pageCount;
        int processA_row = 0;               // 각 PMT에 결과를 반영해주기 위한 row 값  
        int processB_row = 0;
        int processC_row = 0;
        int processD_row = 0;
        int checkMemoryNum = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /* 각 프로세스의 페이지 수 초기 설정 */
            tb_proccessA.Text = "26";
            tb_proccessB.Text = "8";
            tb_proccessC.Text = "19";
            tb_proccessD.Text = "24";

            /* datagridviwe 제목 가운데 정렬 */
            A_PMT.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            B_PMT.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            C_PMT.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            D_PMT.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            mainmemory.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


            /* Main memory 영역의 초기 설정 */
            for (int i = 0; i < 100; i++)           
            {
                mainmemory.Rows.Add(i+1, "");
                mainmemory.Rows[i].Cells[1].Style.BackColor = Color.White;
            }
         
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(mainmemory.Rows[checkMemoryNum].Cells[1].Style.BackColor == Color.White) // 메인 메모리 페이지 프레임에 할당이 안된 상태 
            {
                if(b_activeProceessA)           // 프로세스 A가 동작중이면
                {
                    mainmemory.Rows[checkMemoryNum].Cells[1].Style.BackColor = Color.Red;        // Main Memory에 프로세스 A의 page 적재
                    A_PMT.Rows[processA_row].Cells[1].Value = 1;
                    A_PMT.Rows[processA_row].Cells[2].Value = mainmemory.Rows[checkMemoryNum].Cells[0].Value;       // 프로세스 A의 PMT에 메인 메모리 상황을 반영

                    processA_row++;         // 프로세스 A의 PMT row 값 증가
                    checkMemoryNum++;       // Main Memory의 row 값 증가
                    A_pageCount--;          

                    if (A_pageCount == 0) b_activeProceessA = false;        // A_pageCount가 0이 될 경우 page를 모두 적재했다는 의미 이므로 프로세스 동작 변수를 false로 변환
                }
                
              

                if (b_activeProceessB)          // 프로세스 B가 동작중이면
                {
                    mainmemory.Rows[checkMemoryNum].Cells[1].Style.BackColor = Color.Gold;
                    B_PMT.Rows[processB_row].Cells[1].Value = 1;
                    B_PMT.Rows[processB_row].Cells[2].Value = mainmemory.Rows[checkMemoryNum].Cells[0].Value;

                    processB_row++;
                    checkMemoryNum++;
                    B_pageCount--;
                    if (B_pageCount == 0) b_activeProceessB = false;
                }

               

                if (b_activeProceessC)          // 프로세스 C가 동작중이면
                {
                    mainmemory.Rows[checkMemoryNum].Cells[1].Style.BackColor = Color.Blue;
                    C_PMT.Rows[processC_row].Cells[1].Value = 1;
                    C_PMT.Rows[processC_row].Cells[2].Value = mainmemory.Rows[checkMemoryNum].Cells[0].Value;

                    processC_row++;
                    checkMemoryNum++;
                    C_pageCount--;
                    if (C_pageCount == 0) b_activeProceessC = false;
                }

               

                if (b_activeProceessD)          // 프로세스 D가 동작중이면
                {
                    mainmemory.Rows[checkMemoryNum].Cells[1].Style.BackColor = Color.MediumAquamarine;
                    D_PMT.Rows[processD_row].Cells[1].Value = 1;
                    D_PMT.Rows[processD_row].Cells[2].Value = mainmemory.Rows[checkMemoryNum].Cells[0].Value;

                    processD_row++;
                    checkMemoryNum++;
                    D_pageCount--;
                    if (D_pageCount == 0) b_activeProceessD = false;
                }

            }
           
            mainmemory.Refresh();
            A_PMT.Refresh();
            B_PMT.Refresh();
            C_PMT.Refresh();
            D_PMT.Refresh();
        }

        private void btn_proA_Click(object sender, EventArgs e)
        {
            A_PMT.Rows.Clear();
            timer1.Enabled = true;
            A_pageCount = int.Parse(tb_proccessA.Text);
            for(int i=0; i< A_pageCount; i++)           // 프로세스 A에 page 입력한 page 개수 적용
            {
                A_PMT.Rows.Add(i+1, 0, 0);
            }
            b_activeProceessA = true;
        }

        private void btn_proB_Click(object sender, EventArgs e)
        {
            B_PMT.Rows.Clear();
            timer1.Enabled = true;
            B_pageCount = int.Parse(tb_proccessB.Text);
            for (int i = 0; i < B_pageCount; i++)           // 프로세스 B에 page 입력한 page 개수 적용
            {
                B_PMT.Rows.Add(i + 1, 0, 0);
            }
            b_activeProceessB = true;
        }

        private void btn_proC_Click(object sender, EventArgs e)
        {
            C_PMT.Rows.Clear();
            timer1.Enabled = true;
            C_pageCount = int.Parse(tb_proccessC.Text);
            for (int i = 0; i < C_pageCount; i++)           // 프로세스 C에 page 입력한 page 개수 적용
            {
                C_PMT.Rows.Add(i + 1, 0, 0);
            }
            b_activeProceessC = true;
        }

        private void btn_proD_Click(object sender, EventArgs e)
        {
            D_PMT.Rows.Clear();
            timer1.Enabled = true;
            D_pageCount = int.Parse(tb_proccessD.Text);
            for (int i = 0; i < D_pageCount; i++)              // 프로세스 D에 page 입력한 page 개수 적용
            {
                D_PMT.Rows.Add(i + 1, 0, 0);
            }
            b_activeProceessD = true;
        }
    }
}
