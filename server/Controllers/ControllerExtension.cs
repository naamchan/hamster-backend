using Microsoft.AspNetCore.Mvc;

public static class ControllerExtensions
{
    public static IActionResult Return(this Controller controller)
    {
        return IsHTMLRequest(controller)
            ? controller.View()
            : controller.Ok();
    }

    public static IActionResult Return(this Controller controller, Object obj)
    {
        return IsHTMLRequest(controller)
            ? controller.View(obj)
            : controller.Ok(obj);
    }

    public static IActionResult RedirectOrReturn(this Controller controller, string actionName, Object? obj)
    {
        return IsHTMLRequest(controller)
            ? controller.RedirectToAction(actionName)
            : controller.Ok(obj);
    }

    private static bool IsHTMLRequest(Controller controller)
    {
        var contentType = controller.Request.ContentType;
        var acceptType = controller.Request.Headers.Accept.AsReadOnly();

        return contentType?.Contains("html") ?? false || acceptType.Any(x => x?.Contains("html") ?? false);
    }
}