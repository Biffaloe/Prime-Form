using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FibonacciTest
{
   public partial class PrimeForm : Form
   {
      private int count = 1; // current prime number to display

      public PrimeForm()
      {
         InitializeComponent();
      }



      // start an async Task to calculate specified Prime number
      private async void calculateButton_Click(object sender, EventArgs e)
      {
         // retrieve user's input as an integer
         int number = int.Parse(inputTextBox.Text);

         asyncResultLabel.Text = "Calculating...";

         // Task to perform Prime calculation in separate thread
         Task<long> fibonacciTask = Task.Run(() => FindPrimeNumber(number));

         // wait for Task in separate thread to complete
         await fibonacciTask;

         // display result after Task in separate thread completes
         asyncResultLabel.Text = fibonacciTask.Result.ToString();
      }




      // calculate next Fibonacci number iteratively
      private void nextNumberButton_Click(object sender, EventArgs e)
      {
            int countTwo = 0;
            long a = 2;
            while (countTwo < count)
            {
                long b = 2;
                int prime = 1;// to check if found a prime
                while (b * b <= a)
                {
                    if (a % b == 0)
                    {
                        prime = 0;
                        break;
                    }
                    b++;
                }
                if (prime > 0)
                {
                    countTwo++;
                }
                a++;
            }
            count++;

            // display the next Fibonacci number
            displayLabel.Text = $"The {count} prime:";
            syncResultLabel.Text = (--a).ToString();
      }

        public long FindPrimeNumber(int n)
        {
            int count = 0;
            long a = 2;
            while (count < n)
            {
                long b = 2;
                int prime = 1;// to check if found a prime
                while (b * b <= a)
                {
                    if (a % b == 0)
                    {
                        prime = 0;
                        break;
                    }
                    b++;
                }
                if (prime > 0)
                {
                    count++;
                }
                a++;
            }
            return (--a);
        }
    }
}