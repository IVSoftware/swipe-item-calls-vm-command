Thanks for showing enough code to reproduce your problem. You're saying: 

> My issue is that I cannot get the swipeview properly implemented where its command binds to the RelayCommand in my viewmodel and the commandparameter binds to the type of Model. No matter what I have tried, the swipeviews bindingcontext is ALWAYS of type Model. 

___

From this, my understanding is that the goal is to call a `RelayCommand` like `DeleteLoan` in a view model that "could be" minimally represented similar to this:

~~~
partial class MainPageViewModel : ObservableObject
{
    [RelayCommand]
    private void DeleteLoan(Loan loan)
    {
        Loans.Remove(loan);
    }
    public ObservableCollection<Loan> Loans { get; } = new();
}
~~~

___

Something that works for me is to give an `x:Name` to the view model in the XAML and just use `x:Reference` to access it.


~~~
<ContentPage 
    xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
    xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
    xmlns:local="clr-namespace:LoanShark"
    xmlns:model="clr-namespace:LoanShark.Models"
    xmlns:toolkit="http://schemas.microsoft.com/dotnet/2022/maui/toolkit"
    x:Class="LoanShark.MainPage">
    <ContentPage.BindingContext>
        <local:MainPageViewModel x:Name="MainPageViewModel"/>
    </ContentPage.BindingContext>
    <ContentPage.Resources>
        <ResourceDictionary>
            <local:IsZeroConverter x:Key="IsZeroConverter"/>
            <DataTemplate x:Key="LoanItemTemplate">
                <SwipeView>
                    <SwipeView.LeftItems>
                        <SwipeItems>
                            <SwipeItem 
                                Text="Edit"
                                BackgroundColor="LightGray"/>
                            <SwipeItem 
                                Text="Delete"
                                BackgroundColor="LightPink"  
                                Command="{Binding DeleteLoanCommand, 
                                                  Source={x:Reference MainPageViewModel}}"
                                CommandParameter="{Binding .}" />
                        </SwipeItems>
                    </SwipeView.LeftItems>
                    .
                    .
                    .
                </SwipeView>
            </DataTemplate>
        </ResourceDictionary>
    </ContentPage.Resources>

    <Grid>
        <!-- Show message when Loans is empty -->
        <Label 
            Text="No loans found."
            IsVisible="{Binding Loans.Count, Converter={StaticResource IsZeroConverter}}"
            HorizontalOptions="Center"
            VerticalOptions="Center" />

        <CollectionView
            ItemsSource="{Binding Loans}"
            ItemTemplate="{StaticResource LoanItemTemplate}"
            Margin="20">
        </CollectionView>

        <!-- Floating Add Button -->
        <Button Text="+" 
            Command="{Binding NavigateToNewLoanCommand}"
            HorizontalOptions="End"
            VerticalOptions="End"
            Style="{DynamicResource FloatingActionButtonStyle}" />
    </Grid>
</ContentPage>
~~~