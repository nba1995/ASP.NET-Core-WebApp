using System;
using System.Collections.Generic;
using Corsi.Models.ValueObjects;

namespace Corsi.Models.Entities;

public partial class Course
{
    public Course(string title, string author)
    {
        if(string.IsNullOrEmpty(title))
        {
            throw new ArgumentException("The course must have a title");
        }

        if(string.IsNullOrEmpty(title))
        {
            throw new ArgumentException("The course must have an author");
        }

        Title = title;
        Author = author;
    }
    public long Id { get; private set; }

    public string Title { get; private set; }

    public string Description { get; private set; }

    public string ImagePath { get; private set; }

    public string Author { get; private set; }

    public string Email { get; private  set; }

    public double Rating { get; private set; }

    public string FullPriceAmount { get; set; }

    public string FullPriceCurrency { get; set; }

    public string CurrentPriceAmount { get; set; }

    public string CurrentPriceCurrency { get; set; }

    public Money FullPrice { get; private set; }
    public Money CurrentPrice { get; private set; }

    public virtual ICollection<Lesson> Lessons { get; } = new List<Lesson>();

    public void ChangeTitle(string newTitle)
    {
        if(string.IsNullOrEmpty(newTitle))
        {    
            throw new ArgumentException("The course must have a title");
        }

        Title = newTitle;
    }

    public void ChangePrices(Money newFullPrice, Money newCurrentPrice)
    {
        if (newFullPrice == null || newCurrentPrice == null)
        {
            throw new ArgumentException("Prices can't be null");
        }
        
        if (newFullPrice.Currency != newCurrentPrice.Currency)
        {
            throw new ArgumentException("Currencies don't match");
        }
        
        if (newFullPrice.Amount < newCurrentPrice.Amount)
        {
            throw new ArgumentException("Full price can't be less than the current price");
        }

        FullPrice = newFullPrice;
        CurrentPrice = newCurrentPrice;
    }
}
