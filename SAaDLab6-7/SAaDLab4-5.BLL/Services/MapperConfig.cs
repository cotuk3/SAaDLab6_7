using AutoMapper;
using SAaDLab4_5.BLL.DTO;
using SAaDLab4_5.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAaDLab4_5.BLL.Services;
public class MapperConfig
{
    public static Mapper InitializeAutomapper()
    {
        //Provide all the Mapping Configuration
        var config = new MapperConfiguration(cfg => {
            //Configuring Order and OrderDTO
            cfg.CreateMap<Order, OrderDTO>();
            //Configuring Customer and CustomerDTO
            cfg.CreateMap<Customer, CustomerDTO>();
            //Configuring Quest and QuestDTO
            cfg.CreateMap<Quest, QuestDTO>();
            cfg.CreateMap<OrderDTO, Order>();
            //Configuring Customer and CustomerDTO
            cfg.CreateMap<CustomerDTO, Customer>();
            //Configuring Quest and QuestDTO
            cfg.CreateMap<QuestDTO, Quest>();
        });
        //Create an Instance of Mapper and return that Instance
        var mapper = new Mapper(config);
        return mapper;
    }
}
