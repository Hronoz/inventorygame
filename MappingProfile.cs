using AutoMapper;
using InventoryGame.DTOs;
using InventoryGame.Models;

namespace InventoryGame
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Character, CharacterDto>();

            CreateMap<Item, ItemDto>();

            CreateMap<InventorySlot, InventorySlotDto>()
                .ForMember(dest => dest.ItemId, opt => opt.MapFrom(src => src.Item.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Item.Name))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Item.Type));

            CreateMap<Dictionary<ItemType, Item?>, EquipmentDto>()
                .ForMember(dest => dest.Equipment, opt => opt.MapFrom(src => src));
        }
    }
}
