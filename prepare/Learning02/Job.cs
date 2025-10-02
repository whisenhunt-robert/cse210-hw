// Creates the class for Job.
public class Job
{
    // Creates the string variable for the company name.
    public string _company;
    // Creates the string variable for the job title.
    public string _jobTitle;
    // Creates the integer variable for the starting year.
    public int _startYear;
    // Creates the integer variable for the ending year.
    public int _endYear;

    // Creates the function that displays the company name.
    public void ShowCompanyName()
    {
        // Prints the name of the company.
        Console.WriteLine($"{_company}");
    }

    // Creates the display function that prints the job title, company name, start and end year.
    public void Display()
    {
        Console.WriteLine($"{_jobTitle} ({_company}) {_startYear}-{_endYear}");
    }
}