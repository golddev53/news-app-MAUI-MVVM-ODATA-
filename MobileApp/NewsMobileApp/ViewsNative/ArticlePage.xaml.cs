namespace NewsMobileApp.ViewsNative;

public partial class ArticlePage : ContentPage
{

	public ArticlePage(int articleId)
	{
		InitializeComponent();
        RootComponentControl.Parameters = new Dictionary<string, object> { { "articleid", articleId } };
    }

    private async void DeleteButton_Clicked(object sender, EventArgs e)
    {
        string action = await DisplayActionSheet("������� ������", "������",
            "�������", "�� �������, ��� ������ ������� ������?");
        if (action == "�������")
            await DisplayAlert("�������", "������ �������!", "OK");
    }
}