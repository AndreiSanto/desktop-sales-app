namespace SistemaVendas.Froms
{
    partial class FormListaClientes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            Nome = new DataGridViewTextBoxColumn();
            Email = new DataGridViewTextBoxColumn();
            Telefone = new DataGridViewTextBoxColumn();
            Editar = new DataGridViewButtonColumn();
            Excluir = new DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Nome, Email, Telefone, Editar, Excluir });
            dataGridView1.Location = new Point(1, 456);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(802, 160);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // Nome
            // 
            Nome.HeaderText = "Nome";
            Nome.Name = "Nome";
            // 
            // Email
            // 
            Email.HeaderText = "E-mail";
            Email.Name = "Email";
            // 
            // Telefone
            // 
            Telefone.HeaderText = "Telefone";
            Telefone.Name = "Telefone";
            // 
            // Editar
            // 
            Editar.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Editar.HeaderText = "Editar";
            Editar.Name = "Editar";
            Editar.Text = "bntEditar";
            Editar.ToolTipText = "Editar";
            Editar.UseColumnTextForButtonValue = true;
            // 
            // Excluir
            // 
            Excluir.FlatStyle = FlatStyle.Flat;
            Excluir.HeaderText = "Excluir";
            Excluir.Name = "Excluir";
            Excluir.Text = "bntExcluir";
            // 
            // FormListaClientes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1251, 616);
            Controls.Add(dataGridView1);
            Name = "FormListaClientes";
            Text = "FormListaClientes";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Nome;
        private DataGridViewTextBoxColumn Email;
        private DataGridViewTextBoxColumn Telefone;
        private DataGridViewButtonColumn Editar;
        private DataGridViewButtonColumn Excluir;
    }
}