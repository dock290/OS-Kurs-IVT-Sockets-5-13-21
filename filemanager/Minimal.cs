using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace filemanager
{
    public partial class Minimal : Form
    {
        private readonly FileManager fileManager;

        public Minimal(FileManager fileManager)
        {
            this.fileManager = fileManager;

            InitializeComponent();
        }
    }
}
