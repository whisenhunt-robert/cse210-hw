// Creates the class for Resume.
public class Resume
{
    // Creates the string variable for the name of the person who's resume it is.
    public string _name;
    // Creates a list to store the list of jobs to be displayed on the resume.
    public List<Job> _jobs = new List<Job>();

    // Creates the Display function that displays the person's name and list of jobs.
    public void Display()
    {
        // Prints the name of the person whose resume it is.
        Console.WriteLine($"Name: {_name}");
        // Prints the list of jobs on the person's resume.
        Console.WriteLine($"Jobs: ");

        foreach (Job job in _jobs)
        {
            job.Display();
        }
    }
}