
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinTestApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Calculator : ContentPage
    {
        private Calculation calculation;

        public Calculator()
        {
            InitializeComponent();
            calculation = new Calculation();
        }

        private void Add_Clicked(object sender, System.EventArgs e)
        {
            calculation.CurrentCalculationType = CalculationTypes.Add;
            Result.Text = calculation.Calculate(Value1.Text, Value2.Text);
        }

        private void Minus_Clicked(object sender, System.EventArgs e)
        {
            calculation.CurrentCalculationType = CalculationTypes.Minus;
            Result.Text = calculation.Calculate(Value1.Text, Value2.Text);
        }

        private void Multiply_Clicked(object sender, System.EventArgs e)
        {
            calculation.CurrentCalculationType = CalculationTypes.Multiply;
            Result.Text = calculation.Calculate(Value1.Text, Value2.Text);
        }

        private void Divide_Clicked(object sender, System.EventArgs e)
        {
            calculation.CurrentCalculationType = CalculationTypes.Divide;
            Result.Text = calculation.Calculate(Value1.Text, Value2.Text);
        }

        private void Value1_TextChanged(object sender, TextChangedEventArgs e)
        {
            ValidateValue(sender, e);
            Result.Text = calculation.Calculate(Value1.Text, Value2.Text);
        }

        private void Value2_TextChanged(object sender, TextChangedEventArgs e)
        {
            ValidateValue(sender, e);
            Result.Text = calculation.Calculate(Value1.Text, Value2.Text);
        }

        private void ValidateValue(object sender, TextChangedEventArgs args)
        {
            if (!string.IsNullOrWhiteSpace(args.NewTextValue))
            {
                bool isValid = args.NewTextValue.ToCharArray().All(x => char.IsDigit(x)); //Make sure all characters are numbers
                ((Entry)sender).Text = isValid ? args.NewTextValue : args.NewTextValue.Remove(args.NewTextValue.Length - 1);
            }
        }
    }
}