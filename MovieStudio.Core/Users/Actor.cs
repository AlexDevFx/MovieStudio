﻿using System.Collections.ObjectModel;
using MovieStudio.Contacts;
using MovieStudio.Core.Movies;

namespace MovieStudio.Core.Users;

public class Actor: IHasUpdateTime
{
    public int Id { get; set; }
    public int UserId { get; private set; }
    public User User { get; private set; }
    public Address Address { get; private set; }
    public decimal Compensation { get; private set; }

    public List<Movie> Movies => Offers
        .Where(e => _movieStatuses.Contains(e.Status))
        .Select(e => e.Movie)
        .ToList();
    
    public Collection<MovieOffer> Offers { get; private set; }
    public DateTime? Updated { get; set; }

    private readonly OfferStatus[] _movieStatuses = new[] { OfferStatus.Accepted, OfferStatus.Approved };
}