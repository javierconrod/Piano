using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using NAudio.Mixer;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;

namespace Piano
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private WaveOut waveOut;

        private MixingSampleProvider mixer;

        public MainWindow()
        {

            InitializeComponent();
            waveOut = new WaveOut();
            mixer = new MixingSampleProvider(WaveFormat.CreateIeeeFloatWaveFormat(44100, 1));
            mixer.ReadFully = true;
            waveOut.Init(mixer);
            waveOut.Play();

            KeyDown += MainWindow_KeyDown;

        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.IsRepeat) return;
            if(e.Key == Key.A)
            {
                BtnC_Click(this, null);
            }
            if (e.Key == Key.Q)
            {
                BtnCS_Click(this, null);
            }
            if (e.Key == Key.S)
            {
                BtnD_Click(this, null);
            }
            if (e.Key == Key.W)
            {
                BtnDS_Click(this, null);
            }
            if (e.Key == Key.D)
            {
                BtnE_Click(this, null);
            }
            if (e.Key == Key.F)
            {
                BtnF_Click(this, null);
            }
            if (e.Key == Key.R)
            {
                BtnFS_Click(this, null);
            }
            if (e.Key == Key.G)
            {
                BtnG_Click(this, null);
            }
            if (e.Key == Key.T)
            {
                BtnGS_Click(this, null);
            }
            if (e.Key == Key.H)
            {
                BtnA_Click(this, null);
            }
            if (e.Key == Key.Y)
            {
                BtnAS_Click(this, null);
            }
            if (e.Key == Key.J)
            {
                BtnB_Click(this, null);
            }
            if (e.Key == Key.K)
            {
                BtnC2_Click(this, null);
            }
        }

        private void BtnC_Click(object sender, RoutedEventArgs e)
        {
            var nota_c = NotaC();
            mixer.AddMixerInput(nota_c);
        }

        private void BtnCS_Click(object sender, RoutedEventArgs e)
        {
            var nota_cS = CModificado(1.0 / 12.0);
            mixer.AddMixerInput(nota_cS);
        }

        private void BtnD_Click(object sender, RoutedEventArgs e)
        {
            var nota_d = CModificado(2.0 / 12.0);
            mixer.AddMixerInput(nota_d);
        }
        private void BtnDS_Click(object sender, RoutedEventArgs e)
        {
            var nota_dS = CModificado(3.0 / 12.0);
            mixer.AddMixerInput(nota_dS);
        }
        private void BtnE_Click(object sender, RoutedEventArgs e)
        {
            var nota_e = CModificado(4.0 / 12.0);
            mixer.AddMixerInput(nota_e);
        }

        private void BtnF_Click(object sender, RoutedEventArgs e)
        {
            var nota_f = CModificado(5.0 / 12.0);
            mixer.AddMixerInput(nota_f);
        }
        private void BtnFS_Click(object sender, RoutedEventArgs e)
        {
            var nota_fS = CModificado(6.0 / 12.0);
            mixer.AddMixerInput(nota_fS);
        }
        private void BtnG_Click(object sender, RoutedEventArgs e)
        {
            var nota_g = CModificado(7.0 / 12.0);
            mixer.AddMixerInput(nota_g);
        }
        private void BtnGS_Click(object sender, RoutedEventArgs e)
        {
            var nota_gS = CModificado(8.0 / 12.0);
            mixer.AddMixerInput(nota_gS);
        }
        private void BtnA_Click(object sender, RoutedEventArgs e)
        {
            var nota_a = CModificado(9.0 / 12.0);
            mixer.AddMixerInput(nota_a);
        }
        private void BtnAS_Click(object sender, RoutedEventArgs e)
        {
            var nota_aS = CModificado(10.0 / 12.0);
            mixer.AddMixerInput(nota_aS);
        }
        private void BtnB_Click(object sender, RoutedEventArgs e)
        {
            var nota_b = CModificado(11.0 / 12.0);
            mixer.AddMixerInput(nota_b);
        }

        private void BtnC2_Click(object sender, RoutedEventArgs e)
        {
            var nota_c = CModificado(12.0 / 12.0);
            mixer.AddMixerInput(nota_c);
        }
        private ISampleProvider NotaC()
        {
            var notaC = new SignalGenerator(44100, 1)
            {
                Gain = 0.5f,
                Frequency = 523.251,
                Type = SignalGeneratorType.Sin
            }.Take(TimeSpan.FromMilliseconds(250));

            return notaC;
        }
        private ISampleProvider CModificado(double exponente)
        {
            var nota_c = NotaC();
            var nota_modificada = new SmbPitchShiftingSampleProvider(nota_c);
            nota_modificada.PitchFactor = (float)(Math.Pow(2.0, exponente));

            return nota_modificada;
        }

        
    }
}
