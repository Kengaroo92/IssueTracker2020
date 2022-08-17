using IssueTracker2020.Data;
using IssueTracker2020.Models.ChartModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace IssueTracker2020.Controllers
{
    public class ChartsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ChartsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public JsonResult PriorityChartData()
        {
            List<DonutChart> result = new List<DonutChart>();

            var ticketPriorities = _context.TicketPriorities.ToList();

            foreach (var priority in ticketPriorities)
            {
                result.Add(new DonutChart
                {
                    Label = priority.Name,
                    Value = _context.Tickets.Where(t => t.TicketPriorityId == priority.Id).Count()
                });
            }

            return Json(result);
        }

        public JsonResult StatusChartData()
        {
            List<DonutChart> result = new List<DonutChart>();

            var ticketStatuses = _context.TicketStatuses.ToList();

            foreach (var status in ticketStatuses)
            {
                result.Add(new DonutChart
                {
                    Label = status.Name,
                    Value = _context.Tickets.Where(t => t.TicketStatusId == status.Id).Count()
                });
            }

            return Json(result);
        }

        public JsonResult TypeChartData()
        {
            List<DonutChart> result = new List<DonutChart>();

            var ticketTypes = _context.TicketTypes.ToList();

            foreach (var types in ticketTypes)
            {
                result.Add(new DonutChart
                {
                    Label = types.Name,
                    Value = _context.Tickets.Where(t => t.TicketTypeId == types.Id).Count()
                });
            }

            return Json(result);
        }
    }
}