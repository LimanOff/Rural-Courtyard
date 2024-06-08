using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace RuralCourtyard.Models.Extensions
{
    public static class AlertExtensions
    {
        private const string AlertKey = "SimpleToDo.Alert";

        public static void AddAlertSuccess(this Controller controller, string message)
        {
            var alerts = GetAlerts(controller);

            alerts.Add(new Alert(message, "alert-success1"));

            controller.TempData[AlertKey] = JsonConvert.SerializeObject(alerts);
        }

        public static void AddAlertInfo(this Controller controller, string message)
        {
            var alerts = GetAlerts(controller);

            alerts.Add(new Alert(message, "alert-info"));

            controller.TempData[AlertKey] = JsonConvert.SerializeObject(alerts);
        }

        public static void AddAlertWarning(this Controller controller, string message)
        {
            var alerts = GetAlerts(controller);

            alerts.Add(new Alert(message, "alert-warning"));

            controller.TempData[AlertKey] = JsonConvert.SerializeObject(alerts);
        }

        public static void AddAlertError(this Controller controller, string message)
        {
            var alerts = GetAlerts(controller);

            alerts.Add(new Alert(message, "alert-error"));

            controller.TempData[AlertKey] = JsonConvert.SerializeObject(alerts);
        }

        private static ICollection<Alert> GetAlerts(Controller controller)
        {
            if (controller.TempData[AlertKey] == null)
                controller.TempData[AlertKey] = JsonConvert.SerializeObject(new HashSet<Alert>());

            ICollection<Alert> alerts = JsonConvert.DeserializeObject<ICollection<Alert>>(controller.TempData[AlertKey].ToString());

            if (alerts == null)
            {
                alerts = new HashSet<Alert>();
            }
            return alerts;
        }
    }
}
