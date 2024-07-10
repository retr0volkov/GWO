using System.Windows.Forms;

namespace GWO
{
    public partial class Form1 : Form
    {
        private GreyWolfOptimizer gwo;
        private Bitmap bitmap;
        private Graphics graphics;
        private CancellationTokenSource cancellationTokenSource;

        public Form1()
        {
            InitializeComponent();
            functionSelector.SelectedIndex = 0;
        }

        private double SphereFunction(double[] x)
        {
            return x.Sum(xi => xi * xi);
        }

        private double RastriginFunction(double[] x)
        {
            int n = x.Length;
            return 10 * n + x.Sum(xi => xi * xi - 10 * Math.Cos(2 * Math.PI * xi));
        }

        private double RosenbrockFunction(double[] x)
        {
            double sum = 0.0;
            for (int i = 0; i < x.Length - 1; i++)
            {
                sum += 100 * Math.Pow(x[i + 1] - x[i] * x[i], 2) + Math.Pow(x[i] - 1, 2);
            }
            return sum;
        }

        private double AckleyFunction(double[] x)
        {
            int n = x.Length;
            double sum1 = x.Sum(xi => xi * xi);
            double sum2 = x.Sum(xi => Math.Cos(2 * Math.PI * xi));
            return -20 * Math.Exp(-0.2 * Math.Sqrt(sum1 / n)) - Math.Exp(sum2 / n) + 20 + Math.E;
        }

        private double GriewankFunction(double[] x)
        {
            double sum = 0.0;
            double prod = 1.0;
            for (int i = 0; i < x.Length; i++)
            {
                sum += x[i] * x[i] / 4000;
                prod *= Math.Cos(x[i] / Math.Sqrt(i + 1));
            }
            return sum - prod + 1;
        }

        private void DrawOptimizationProcess(int iteration)
        {
            graphics.Clear(Color.White);

            foreach (var wolf in gwo.wolves)
            {
                float x = (float)(wolf[0] * 10 + pictureBox.Width / 2);
                float y = (float)(wolf[1] * 10 + pictureBox.Height / 2);
                graphics.FillEllipse(Brushes.Gray, x, y, 5, 5);
            }

            graphics.FillEllipse(Brushes.Red, (float)(gwo.alpha[0] * 10 + pictureBox.Width / 2), (float)(gwo.alpha[1] * 10 + pictureBox.Height / 2), 10, 10);
            graphics.FillEllipse(Brushes.Blue, (float)(gwo.beta[0] * 10 + pictureBox.Width / 2), (float)(gwo.beta[1] * 10 + pictureBox.Height / 2), 8, 8);
            graphics.FillEllipse(Brushes.Green, (float)(gwo.delta[0] * 10 + pictureBox.Width / 2), (float)(gwo.delta[1] * 10 + pictureBox.Height / 2), 6, 6);

            graphics.DrawString($"Итерация: {iteration + 1}", new Font("Arial", 12), Brushes.Black, new PointF(10, 10));

            pictureBox.Image = bitmap;
            this.Invalidate();
        }


        private void startButton_Click(object sender, EventArgs e)
        {
            int populationSize = int.Parse(populationSizeBox.Text);
            int maxIterations = int.Parse(maxIterationsBox.Text);
            double lowerBound = double.Parse(lowerBoundBox.Text);
            double upperBound = double.Parse(upperBoundBox.Text);

            bitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
            graphics = Graphics.FromImage(bitmap);
            pictureBox.Image = bitmap;

            Func<double[], double> objectiveFunction = null;
            switch (functionSelector.SelectedItem.ToString())
            {
                case "Сферическая функция":
                    objectiveFunction = SphereFunction;
                    break;
                case "Функция Растригина":
                    objectiveFunction = RastriginFunction;
                    break;
                case "Функция Розенброка":
                    objectiveFunction = RosenbrockFunction;
                    break;
                case "Функция Акли":
                    objectiveFunction = AckleyFunction;
                    break;
                case "Функция Гриванка":
                    objectiveFunction = GriewankFunction;
                    break;
                default:
                    objectiveFunction = SphereFunction;
                    break;
            }

            gwo = new GreyWolfOptimizer(populationSize, maxIterations, lowerBound, upperBound, objectiveFunction);

            cancellationTokenSource = new CancellationTokenSource();
            var token = cancellationTokenSource.Token;

            Task.Run(() =>
            {
                for (int iteration = 0; iteration < maxIterations; iteration++)
                {
                    if (token.IsCancellationRequested)
                    {
                        break; 
                    }
                    gwo.OptimizeOneIteration();
                    Invoke(new Action(() =>
                    {
                        DrawOptimizationProcess(iteration);
                    }));
                    Thread.Sleep(1000); // Обновляем каждые 100 мс
                }
            }, token);
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            cancellationTokenSource?.Cancel();
        }
    }
}
