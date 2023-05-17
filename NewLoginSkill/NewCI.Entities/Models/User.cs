using System;
using System.Collections.Generic;

namespace NewCI.Entities.Models;

public partial class User
{
    public long UserId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public string? Avtar { get; set; }

    public string? WhyIVolunteer { get; set; }

    public string? EmployeeId { get; set; }

    public string? Department { get; set; }

    public long? CityId { get; set; }

    public long? CountryId { get; set; }

    public string? ProfileText { get; set; }

    public string? LinkedInUrl { get; set; }

    public string? Title { get; set; }

    public bool? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public string? Availability { get; set; }

    public string? Manager { get; set; }

    public string Role { get; set; } = null!;

    public string? AuthRole { get; set; }

    public virtual City? City { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual Country? Country { get; set; }

    public virtual ICollection<FavouriteMission> FavouriteMissions { get; set; } = new List<FavouriteMission>();

    public virtual ICollection<MissionApplication> MissionApplications { get; set; } = new List<MissionApplication>();

    public virtual ICollection<MissionInvite> MissionInviteFromUsers { get; set; } = new List<MissionInvite>();

    public virtual ICollection<MissionInvite> MissionInviteToUsers { get; set; } = new List<MissionInvite>();

    public virtual ICollection<MissionRating> MissionRatings { get; set; } = new List<MissionRating>();

    public virtual ICollection<Story> Stories { get; set; } = new List<Story>();

    public virtual ICollection<StoryInvite> StoryInviteFromUsers { get; set; } = new List<StoryInvite>();

    public virtual ICollection<StoryInvite> StoryInviteToUsers { get; set; } = new List<StoryInvite>();

    public virtual ICollection<Timesheet> Timesheets { get; set; } = new List<Timesheet>();

    public virtual ICollection<UserSkill> UserSkills { get; set; } = new List<UserSkill>();
}
