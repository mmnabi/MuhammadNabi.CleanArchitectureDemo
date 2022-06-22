using MediatR;
using System;
using System.Linq;
using System.Text;

namespace MuhammadNabi.CleanArchitectureDemo.Application.Features.Orders.Queries.GetOrdersForMonth
{
    public class GetOrdersForMonthQuery : IRequest<PagedOrdersForMonthVm>
    {
        public DateTime Date { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }
    }
}
