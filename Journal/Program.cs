using System;

class Journal
{
    
    private string title;
    private int yearFounded;
    private string description;
    private string contactPhone;
    private string contactEmail;

    
    public Journal(string title, int yearFounded, string description, string contactPhone, string contactEmail)
    {
        this.title = title;
        this.yearFounded = yearFounded;
        this.description = description;
        this.contactPhone = contactPhone;
        this.contactEmail = contactEmail;
    }

    
    public string Title
    {
        get { return title; }
        set { title = value; }
    }

    
    public int YearFounded
    {
        get { return yearFounded; }
        set { yearFounded = value; }
    }

    
    public string Description
    {
        get { return description; }
        set { description = value; }
    }

    
    public string ContactPhone
    {
        get { return contactPhone; }
        set { contactPhone = value; }
    }

    
    public string ContactEmail
    {
        get { return contactEmail; }
        set { contactEmail = value; }
    }

    public void DisplayJournalInfo()
    {
        Console.WriteLine($"Название журнала: {Title}");
        Console.WriteLine($"Год основания: {YearFounded}");
        Console.WriteLine($"Описание журнала: {Description}");
        Console.WriteLine($"Контактный телефон: {ContactPhone}");
        Console.WriteLine($"Контактный e-mail: {ContactEmail}");
    }
}

class Program
{
    static void Main()
    {
        
        Journal journal = new Journal("Наука и жизнь", 1995, "Это журнал о научных открытиях", "123-456-7890", "123@mail.ru");

       
        journal.DisplayJournalInfo();

        
        journal.Title = "Мурзилка";

        journal.DisplayJournalInfo();
    }
}
