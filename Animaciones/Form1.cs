using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Animaciones
{
    public partial class MainForm : Form
    {
        private int XPos = 0; // Posición inicial en el eje X
        private SoundPlayer soundPlayer; // Declara un objeto SoundPlayer
        public MainForm()
        {
            InitializeComponent();
            InitializeAnimation();
            InitializeSound(); // Inicializa el objeto SoundPlayer
        }
        private void InitializeAnimation()
        {
            // Configurar el temporizador para la animación
            Timer animationTimer = new Timer();
            animationTimer.Interval = 100; // Intervalo en milisegundos
            animationTimer.Tick += timer1_Tick;
            animationTimer.Start();
        }
        private void InitializeSound()
        {
            // Ruta del archivo de sonido (puedes cambiarlo a la ubicación de tu archivo de sonido)
            string soundFilePath = @"C:\Users\Paul\Music\sonido.wav";
            // Inicializa el objeto SoundPlayer con la ruta del archivo de sonido
            soundPlayer = new SoundPlayer(soundFilePath);
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            // Puedes agregar otros elementos como gráficos, audio, etc., en este evento o en el diseñador
            // Por ejemplo, aquí estoy agregando un Label para animar
            System.Windows.Forms.Label label = new System.Windows.Forms.Label();
            label.Text = "¡Animación!";
            label.AutoSize = true;
            label.Location = new System.Drawing.Point(0, 50);
            this.Controls.Add(label);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            // Actualizar la posición del elemento animado (en este caso, un Label)
            XPos += 5; // Incremento en la posición X
            // Verificar si la animación ha llegado al final
            if (XPos > this.Width)
            {
                XPos = 0; // Reiniciar la animación al llegar al final
            }
            // Actualizar la posición del elemento en la interfaz
            label1.Location = new System.Drawing.Point(XPos, label1.Location.Y);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            soundPlayer.Play();
        }
    }
}