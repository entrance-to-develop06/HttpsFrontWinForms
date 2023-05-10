using HttpsFrontWinForms.FormDesign;
using HttpsFrontWinForms.Http;

namespace HttpsFrontWinForms
{
    public partial class FormAuthControl : Form
    {
        private FormAuthDesign fDesign = new FormAuthDesign();

        public FormAuthControl()
        {
            InitializeComponent();
            CreateForm();
        }

        private void ButtonAuth_Click(object sender, EventArgs e)
        {
            Authentication.UserID = fDesign.TextBoxUserName.Text;
            Authentication.Password = fDesign.TextBoxPassword.Text;
            this.Close();
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CreateForm()
        {
            this.Name = "FormAuthControl";
            this.Text = "認証";
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new System.Drawing.Point(600, 250);
            this.Size = new Size(450, 250);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;

            foreach (var label in fDesign.LabelDic)
                Controls.Add(label.Value);
            Controls.Add(fDesign.TextBoxUserName);
            Controls.Add(fDesign.TextBoxPassword);

            Controls.Add(fDesign.ButtonAuth);
            fDesign.ButtonAuth.Click += new EventHandler(ButtonAuth_Click!);

            Controls.Add(fDesign.ButtonCancel);
            fDesign.ButtonCancel.Click += new EventHandler(ButtonCancel_Click!);
        }
    }
}