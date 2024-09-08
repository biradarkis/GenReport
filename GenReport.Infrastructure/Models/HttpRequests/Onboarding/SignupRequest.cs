using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenReport.Infrastructure.Models.HttpRequests.Onboarding
{
    public class SignupRequest
    {

        /// <summary>
        /// Gets or sets the Email
        /// </summary>
        public required string Email { get; set; }

        /// <summary>
        /// Gets or sets the FirstName
        /// </summary>
        public required string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the LastName
        /// </summary>
        public required string LastName { get; set; }

        /// <summary>
        /// Gets or sets the MiddleName
        /// </summary>
        public string? MiddleName { get; set; }

        /// <summary>
        /// Gets or sets the Password
        /// </summary>
        public required string Password { get; set; }


    }
}
