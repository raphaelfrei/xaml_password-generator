using System.Text;

namespace PasswordGenerator;

public partial class MainPage : ContentPage{

    public MainPage(){
        InitializeComponent();
    }

    void SldLength_ValueChanged(System.Object sender, Microsoft.Maui.Controls.ValueChangedEventArgs e){
        LbLength.Text = $"THE LENGTH IS: {Convert.ToInt32(SldLength.Value):00}";
    }

    void BtGen_Clicked(System.Object sender, System.EventArgs e){

        string chars = $"";

        if (CbSmall.IsChecked)
            chars += $"abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyz";

        if (CbCapital.IsChecked)
            chars += $"ABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZ";

        if (CbNumbers.IsChecked)
            chars += $"01234567890123456789";

        if (CbSpecial.IsChecked)
            chars += $"!@#$%&*()_+-=˜{{}}[]|\\:;\"/?.>,<çÇ";

        if (chars == string.Empty) {
            DisplayAlert("Alert", "Select at least one filter before continue.", "OK");
            BtCopy.IsEnabled = false;
            EtPassword.Text = $"";
            return;
        }

        int passwordLength = Convert.ToInt32(SldLength.Value);

        string password = $"";

        Random rnd = new Random();

        for (int i = 0; i < passwordLength; i++) 
            password += chars[rnd.Next(0, chars.Length - 1)];

        EtPassword.Text = password;
        BtCopy.IsEnabled = true;

    }

    void BtCopy_Clicked(System.Object sender, System.EventArgs e){

        Clipboard.SetTextAsync(EtPassword.Text);

        DisplayAlert("Success", "Password copied into clipboard!", "OK");

    }
}


