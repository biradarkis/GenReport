using FastEndpoints;
using GenReport.Domain.DBContext;
using GenReport.Infrastructure.Models.HttpResponse.Dashboard;
using GenReport.Services.Interfaces;

namespace GenReport.Endpoints.Dashboard
{
    public class RecentQueries(ApplicationDbContext context, ICurrentUserService currentUserService) : EndpointWithoutRequest<RecentQueriesResponse>
    {
        private readonly ApplicationDbContext _context = context;
        private readonly ICurrentUserService _currentUserService = currentUserService;

        public override void Configure()
        {
            Get("dashboard/reports");
        }

        public override Task HandleAsync(CancellationToken ct)
        {
            var userId  =  _currentUserService.LoggedInUserId();
            var reports = _context.Reports.Where(x => x.Query.CreatedById == userId).Select(x=> new  );
        }
    }
}
