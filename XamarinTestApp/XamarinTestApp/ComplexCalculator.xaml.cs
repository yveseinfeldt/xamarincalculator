using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinTestApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ComplexCalculator : ContentPage
	{
        public ComplexCalculator()
        {
            InitializeComponent();
            Result.Clicked += async delegate
            {
                string lastCharacter = ResultEntry.Text.ToCharArray().LastOrDefault().ToString();
                int a = 0;
                if (int.TryParse(lastCharacter, out a))
                {
                    ResultEntry.Text = await Calculate(ResultEntry.Text);
                }
            };
        }

        private void WriteText(object senderButtonAsObject, EventArgs e)
        {
            var senderButton = (Button)senderButtonAsObject;
            string lastCharacter = ResultEntry.Text.ToCharArray().LastOrDefault().ToString();

            if (lastCharacter == senderButton.Text && IsSymbol(senderButton.Text))
            {
                // do not add value
                return;
            }

            if (IsSymbol(lastCharacter) && IsSymbol(senderButton.Text))
            {
                ResultEntry.Text = ResultEntry.Text.Remove(ResultEntry.Text.Length - 1);
                ResultEntry.Text += senderButton.Text;
                return;
            }

            ResultEntry.Text += senderButton.Text;
        }

        private bool IsDigit(string character)
        {
            int donotneedthis;
            return int.TryParse(character, out donotneedthis);
        }

        private bool IsSymbol(string character)
        {
            return character == "+" || character == "-" || character == "*" || character == "/";
        }

        private async Task<string> Calculate(string calculationFormula)
        {
            return new DataTable().Compute(calculationFormula, null).ToString();
        }
    }
}