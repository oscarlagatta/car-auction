using AuctionService.DTOs;
using AuctionService.Entities;
using AutoMapper;
using Contracts;

namespace AuctionService.RequestHelpers;

public class MappingProfiles: Profile
{
    /// Defines mapping profiles for AutoMapper used in the AuctionService application.
    /// This profile establishes mappings between entities and DTOs relevant to auctions and items.
    /// Mappings:
    /// - `Auction` maps to `AuctionDto`, including members from the related `Item`.
    /// - `Item` maps to `AuctionDto`.
    /// - `CreateAuctionDto` maps to `Auction` where the `Item` property is mapped from the same source object.
    /// - `CreateAuctionDto` also maps to `Item`.
    /// This is designed to streamline the conversion of domain models to data transfer objects (DTOs)
    /// and vice versa for API communication and persistence.
    public MappingProfiles()
    {
        CreateMap<Auction, AuctionDto>().IncludeMembers(x => x.Item);
        CreateMap<Item, AuctionDto>();
        CreateMap<CreateAuctionDto, Auction>()
            .ForMember(d => d.Item, o => o.MapFrom(s => s));
        CreateMap<CreateAuctionDto, Item>();
        CreateMap<AuctionDto, AuctionCreated>();
        CreateMap<Auction, AuctionUpdated>().IncludeMembers(x => x.Item);
        CreateMap<Item, AuctionUpdated>();
    }
}