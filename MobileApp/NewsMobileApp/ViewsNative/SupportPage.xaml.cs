namespace NewsMobileApp.ViewsNative;

public partial class SupportPage : ContentPage
{

	public SupportPage()
	{
		InitializeComponent();
        ComboBox1.ItemsSource = new[] {
            "�������� �� ������",
            "�������� � ������� �������",
            "������� ��������������",
            "������"
        };
        ComboBox1.SelectedIndex = 0;
    }

    private async void Submit_Clicked(object sender, EventArgs e) =>
        await DisplayAlert("����������", "��� ������ ��������� ����� ������ ���������. �������� ������!", "OK");
}