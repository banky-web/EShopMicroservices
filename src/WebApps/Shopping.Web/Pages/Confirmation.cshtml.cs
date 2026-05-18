namespace Shopping.Web.Pages
{
    public class ConfirmationModel : PageModel
    {
        public string Message { get; set; } = default!;
        public void OnGetContact()
        {
            Message = "Your email was Sent.";
        }

        public void OnGetOrderSubmitted()
        {
            Message = "Your order was submitted successfully.";
        }
    }
}
