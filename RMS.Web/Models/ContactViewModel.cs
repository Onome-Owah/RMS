namespace RMS.Web.Models;

public class ContactViewModel
{
    public string Title { get; set; }
    public string Message { get; set; }
    public DateTime Formed { get; set; } = DateTime.Now;
    public string FormedString => Formed.ToLongDateString();
    public int Days => (DateTime.Now - Formed).Days;

}