namespace VisualCSharp
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button9 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(28, 41);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(213, 50);
            this.button1.TabIndex = 0;
            this.button1.Text = "예제 1 - 루아 스크립트 \r\n파일 실행하기";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(28, 115);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(213, 50);
            this.button2.TabIndex = 0;
            this.button2.Text = "예제 2 - 루아 전역 변수 \r\n조작하기";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(28, 189);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(213, 50);
            this.button3.TabIndex = 0;
            this.button3.Text = "예제 3 - 루아 함수\r\n호출하기";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(278, 41);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(213, 50);
            this.button4.TabIndex = 0;
            this.button4.Text = "예제 4 - 루아에서 호출 가능한\r\nC# 함수 만들기 1";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(278, 115);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(213, 50);
            this.button5.TabIndex = 0;
            this.button5.Text = "예제 5 - 루아에서 호출 가능한\r\nC# 함수 만들기 2\r\n";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(278, 189);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(213, 50);
            this.button6.TabIndex = 0;
            this.button6.Text = "예제 6 - 루아에서 호출 가능한\r\nC# 함수 만들기 3\r\n";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(526, 41);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(213, 50);
            this.button7.TabIndex = 0;
            this.button7.Text = "예제 7 - MyDbgString을 DLL로\r\n구현하기";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(526, 115);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(213, 50);
            this.button8.TabIndex = 0;
            this.button8.Text = "예제 8 - DLL을 루아 스크립트에서\r\n직접 호출할 수 있도록 만들기";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(242, 242);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "1 장 - C#에서 Lua 호출하기";
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(267, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(242, 242);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "2 장 - Lua에서 C# 호출하기";
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(515, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(242, 242);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "3 장 - Lua 확장 모듈(DLL) 만들기";
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(12, 274);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(745, 61);
            this.button9.TabIndex = 4;
            this.button9.Text = "종료";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(776, 349);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Name = "Form1";
            this.Text = "Visual C# 개발자 Lua를 만나다";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button9;
    }
}

