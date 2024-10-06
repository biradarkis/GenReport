using CoreDdd.Domain.Events;
using GenReport.DB.Domain.Interfaces;
using GenReport.Domain.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenReport.DB.Domain.Events
{
    public class ForgotPasswordEvent : IDomainEvent
    {
        public long Id { get; set; }
    }

    internal class ForgotPasswordEventHandler(ApplicationDbContext context) : IDomainEventHandler<ForgotPasswordEvent>
    {
        private readonly ApplicationDbContext _context = context;

        public void Handle(ForgotPasswordEvent domainEvent)
        {

        }
    }
}
