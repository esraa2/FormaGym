using AutoMapper;
using Forma_Gym.DTOs;
using Forma_Gym.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forma_Gym.App_Start
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<FormaActivity, FormaActivityDto>();
			CreateMap<FormaActivityDto, FormaActivity>()
				.ForMember(c => c.Id, opt => opt.Ignore());

			CreateMap<Classes, ClassesDto>();
			CreateMap<ClassesDto, Classes>()
				.ForMember(c => c.Id, opt => opt.Ignore());

			CreateMap<Subscriber, SubscriberDto>();
			CreateMap<SubscriberDto, Subscriber>()
				.ForMember(c => c.Id, opt => opt.Ignore());

			CreateMap<Subscription, SubscriptionDto>();
			CreateMap<SubscriptionDto, Subscription>()
				.ForMember(c => c.Id, opt => opt.Ignore());

		}
	}
}