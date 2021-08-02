using Syncfusion.XForms.MaskedEdit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TestSFnPrism
{
    public partial class MainPage : ContentPage
    {
        string last11Value = "";
        bool check = false;

        public MainPage()
        {
            InitializeComponent();

            txtIdentificador.ValidationMode = InputValidationMode.KeyPress;
            txtIdentificador.ValueMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            //txtIdentificador.ValueChanged += TxtIdentificador_ValueChanged;
            /*txtIdentificador.PropertyChanging += TxtIdentificador_PropertyChanging;

            txtIdentificador2.ValidationMode = InputValidationMode.KeyPress;
            txtIdentificador2.ValueMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            txtIdentificador2.PropertyChanging += TxtIdentificador_PropertyChanging;

            txtIdentificador3.ValidationMode = InputValidationMode.KeyPress;
            txtIdentificador3.ValueMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            txtIdentificador3.PropertyChanging += TxtIdentificador_PropertyChanging;*/
        }

        private void TxtIdentificador_ValueChanged(object sender, Syncfusion.XForms.MaskedEdit.ValueChangedEventArgs eventArgs)
        {
            Debug.WriteLine(">>> sender: " + ((SfMaskedEdit)sender).Value.ToString());
            Debug.WriteLine(">>> eventArgs: " + eventArgs.Value);
            Debug.WriteLine(">>> txtIdentificador: " + txtIdentificador.Value.ToString());

            if (!check)
            {
                check = last11Value.Length == 12;
            }

            if (!string.IsNullOrEmpty(eventArgs.Value.ToString()))
                last11Value = eventArgs.Value.ToString();

            if (eventArgs.Value.ToString().Length == 0 && check)
            {
                txtIdentificador.MaskType = MaskType.RegEx;
                txtIdentificador.Mask = @"\d{4} \d{4} \d{3} \d*";
                txtIdentificador.Value = last11Value;
                txtIdentificador.MaskType = MaskType.RegEx;
                txtIdentificador.Mask = @"\d{4} \d{4} \d{3} \d*";
                check = false;
            }
        }

        /*
        private void TxtIdentificador_PropertyChanging(object sender, Xamarin.Forms.PropertyChangingEventArgs e)
        {
            
            if (e.PropertyName.Equals("IsVisible"))
            {
                txtIdentificador2.Focus();

            }
        }
        */
        protected override void OnAppearing() { txtIdentificador.Focus(); base.OnAppearing(); }
    }
}
