using NewsApp.models;
using NewsApp.Services;

namespace NewsApp.Page;

public partial class NewListPage : ContentPage
{
	public List<Article> ArticlesList;

    public NewListPage(string categoryName)
	{
		InitializeComponent();
		Title = categoryName;
		GetNews(categoryName);
		ArticlesList = new List<Article>();
	}

	private async void GetNews(string catagoryName)
	{
		var apiService = new ApiService();
		var newsResult = await apiService.GetNews(catagoryName);
		foreach(var item in newsResult.Articles)
		{
			ArticlesList.Add(item);
		}
		CvNews.ItemsSource = ArticlesList;
	}
	
    private void CvNews_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
    {
        var selectedItem = e.CurrentSelection.FirstOrDefault() as Article;
        if (selectedItem == null) return;
        Navigation.PushAsync(new NewsDetailPage(selectedItem));
        ((CollectionView)sender).SelectedItem = null;
    }

    
}