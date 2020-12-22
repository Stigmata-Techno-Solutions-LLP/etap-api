using System.Collections.Generic;
using ETapManagement.ViewModel.Dto;
using ETapManagement.Repository;
using Microsoft.Extensions.Options;

namespace ETapManagement.Service
{
	public class StructureService : IStructureService
	{
		IStructureRepository _structureRepository;

		private readonly AppSettings _appSettings;

		public StructureService(IOptions<AppSettings> appSettings, IStructureRepository structureRepository)
		{
			_structureRepository = structureRepository;
			_appSettings = appSettings.Value;
		}

		public List<StructureDetails> GetStructures()
		{
			List<StructureDetails> structures = _structureRepository.GetStructure();
			if (!(structures?.Count > 0)) return null;

			return structures;
		}

		public StructureDetails GetStructureById(int id)
		{
			StructureDetails structure = _structureRepository.GetStructureById(id);
			if (structure == null) return null;

			return structure;
		}
			public StructureComponentDetails GetStructureCompById(int id)
		{
			StructureComponentDetails structure = _structureRepository.GetStructureCompById(id);
			if (structure == null) return null;

			return structure;
		}

		public ResponseMessage AddStructure(StructureDetails structure)
		{
			ResponseMessage responseMessage = new ResponseMessage();
			responseMessage = _structureRepository.AddStructure(structure);

			if (responseMessage != null)
				return responseMessage;
			else
			{
				return new ResponseMessage()
				{
					Message = "",
				};
			}
		}

		public ResponseMessage UpdateStructure(StructureDetails structure, int id)
		{
			ResponseMessage responseMessage = new ResponseMessage();
			responseMessage = _structureRepository.UpdateStructure(structure, id);
			return responseMessage;
		}

		public ResponseMessage DeleteStructure(int id)
		{
			ResponseMessage responseMessage = new ResponseMessage();
			responseMessage = _structureRepository.DeleteStructure(id);
			return responseMessage;
		}
	}
}