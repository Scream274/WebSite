using WebSite.Entities;

namespace WebSite.Services
{
    public static class HtmlService
    {
        public static string GetDaysSince(DateTime date)
        {
            int days = (int)(DateTime.Now - date).TotalDays;
            if (days == 0)
            {
                return "today";
            }
            else if (days == 1)
            {
                return "yesterday";
            }
            else
            {
                return days + " days ago";
            }
        }

        public static int CountAllComments(List<Comment> comments)
        {
            int count = 0;
            if (comments == null)
            {
                return 0;
            }
            foreach (var comment in comments)
            {

                count++; // Count the current comment
                if (comment.Childs != null)
                {
                    count += CountAllComments(comment.Childs.ToList()); // Count the replies recursively
                }
            }
            return count;
        }
    }
}
