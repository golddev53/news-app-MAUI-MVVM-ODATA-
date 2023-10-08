using NewsMobileApp.TempServices;

namespace NewsMobileApp.ViewsNative;

public partial class ArticlePage : ContentPage
{
    private readonly int _articleId;

	public ArticlePage(int articleId)
	{
		InitializeComponent();
        _articleId = articleId;
        RootComponentControl.Parameters = new Dictionary<string, object> { { "articleid", _articleId } };
    }

    private async void DeleteButton_Clicked(object sender, EventArgs e)
    {
        string action = await DisplayActionSheet("������� ������", "������",
            "�������", "�� �������, ��� ������ ������� ������?");
        if (action == "�������")
            await DisplayAlert("�������", "������ �������!", "OK");
    }

    private async void EditButton_Clicked(object sender, EventArgs e) =>
        await Navigation.PushAsync(new ArticleDetailPage(new NewsService(), _articleId));
}