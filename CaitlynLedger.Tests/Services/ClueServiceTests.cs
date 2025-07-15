using AutoMapper;
using CaitlynsLedger.Application.Services;
using CaitlynsLedger.Domain.Entities;
using CaitlynsLedger.Domain.Interfaces;
using CaitlynsLedgerAPI.CaitlynsLedger.Application;
using FluentAssertions;
using Moq;

namespace CaitlynLedger.Tests.Services;

public class ClueServiceTests
{
    private readonly Mock<IClueRepository> _mockClueRepository;
    private readonly Mock<IMapper> _mockMapper;
    private readonly ClueService _clueService;

    public ClueServiceTests()
    {
        _mockClueRepository = new Mock<IClueRepository>();
        _mockMapper = new Mock<IMapper>();
        _clueService = new ClueService(_mockClueRepository.Object, _mockMapper.Object);
    }

    [Fact]
    public async Task GetByIdAsync_ExistingClue_ReturnsClue()
    {
        // Arrange
        var clueId = 1;
        var expectedClue = new Clue
        {
            Id = clueId,
            Title = "Pista Importante",
            Description = "Descrição da pista",
            Location = "Biblioteca",
            CaseId = 1
        };
        
        var expectedDto = new ClueDTO.ClueDto
        {
            Id = clueId,
            Title = "Pista Importante",
            Description = "Descrição da pista",
            Location = "Biblioteca",
            DiscoveryDate = DateTime.Now,
            CaseId = 1
        };
        
        _mockClueRepository.Setup(x => x.GetByIdAsync(clueId))
            .ReturnsAsync(expectedClue);
        
        _mockMapper.Setup(x => x.Map<ClueDTO.ClueDto>(expectedClue))
            .Returns(expectedDto);

        // Act
        var result = await _clueService.GetByIdAsync(clueId);

        // Assert
        result.Should().NotBeNull();
        result.Id.Should().Be(clueId);
        result.Title.Should().Be("Pista Importante");
        result.Description.Should().Be("Descrição da pista");
        result.Location.Should().Be("Biblioteca");
    }

    [Fact]
    public async Task GetByIdAsync_NonExistingClue_ReturnsNull()
    {
        // Arrange
        var clueId = 999;
        _mockClueRepository.Setup(x => x.GetByIdAsync(clueId))
            .ReturnsAsync((Clue?)null);
        
        _mockMapper.Setup(x => x.Map<ClueDTO.ClueDto>(null))
            .Returns((ClueDTO.ClueDto?)null);

        // Act
        var result = await _clueService.GetByIdAsync(clueId);

        // Assert
        result.Should().BeNull();
    }

    [Fact]
    public async Task GetAllAsync_HasClues_ReturnsListOfClues()
    {
        // Arrange
        var clues = new List<Clue>
        {
            new Clue { Id = 1, Title = "Pista 1", Description = "Desc 1", Location = "Local 1", CaseId = 1 },
            new Clue { Id = 2, Title = "Pista 2", Description = "Desc 2", Location = "Local 2", CaseId = 1 }
        };

        var clueDtos = new List<ClueDTO.ClueDto>
        {
            new ClueDTO.ClueDto { Id = 1, Title = "Pista 1", Description = "Desc 1", Location = "Local 1", DiscoveryDate = DateTime.Now, CaseId = 1 },
            new ClueDTO.ClueDto { Id = 2, Title = "Pista 2", Description = "Desc 2", Location = "Local 2", DiscoveryDate = DateTime.Now, CaseId = 1 }
        };

        _mockClueRepository.Setup(x => x.GetAllAsync())
            .ReturnsAsync(clues);
        
        _mockMapper.Setup(x => x.Map<IEnumerable<ClueDTO.ClueDto>>(clues))
            .Returns(clueDtos);

        // Act
        var result = await _clueService.GetAllAsync();

        // Assert
        result.Should().NotBeNull();
        result.Should().HaveCount(2);
        result.First().Title.Should().Be("Pista 1");
        result.Last().Title.Should().Be("Pista 2");
    }

    [Fact]
    public async Task GetAllAsync_NoClues_ReturnsEmptyList()
    {
        // Arrange
        var emptyClues = new List<Clue>();
        var emptyDtos = new List<ClueDTO.ClueDto>();

        _mockClueRepository.Setup(x => x.GetAllAsync())
            .ReturnsAsync(emptyClues);
        
        _mockMapper.Setup(x => x.Map<IEnumerable<ClueDTO.ClueDto>>(emptyClues))
            .Returns(emptyDtos);

        // Act
        var result = await _clueService.GetAllAsync();

        // Assert
        result.Should().NotBeNull();
        result.Should().BeEmpty();
    }

    [Fact]
    public async Task GetByCaseIdAsync_ExistingCase_ReturnsCluesForCase()
    {
        // Arrange
        var caseId = 1;
        var clues = new List<Clue>
        {
            new Clue { Id = 1, Title = "Pista A", Description = "Desc A", Location = "Local A", CaseId = caseId },
            new Clue { Id = 2, Title = "Pista B", Description = "Desc B", Location = "Local B", CaseId = caseId }
        };

        var clueDtos = new List<ClueDTO.ClueDto>
        {
            new ClueDTO.ClueDto { Id = 1, Title = "Pista A", Description = "Desc A", Location = "Local A", DiscoveryDate = DateTime.Now, CaseId = caseId },
            new ClueDTO.ClueDto { Id = 2, Title = "Pista B", Description = "Desc B", Location = "Local B", DiscoveryDate = DateTime.Now, CaseId = caseId }
        };

        _mockClueRepository.Setup(x => x.GetByCaseIdAsync(caseId))
            .ReturnsAsync(clues);
        
        _mockMapper.Setup(x => x.Map<IEnumerable<ClueDTO.ClueDto>>(clues))
            .Returns(clueDtos);

        // Act
        var result = await _clueService.GetByCaseIdAsync(caseId);

        // Assert
        result.Should().NotBeNull();
        result.Should().HaveCount(2);
        result.Should().OnlyContain(c => c.CaseId == caseId);
        result.First().Title.Should().Be("Pista A");
    }

    [Fact]
    public async Task GetByCaseIdAsync_NonExistingCase_ReturnsEmptyList()
    {
        // Arrange
        var caseId = 999;
        var emptyClues = new List<Clue>();
        var emptyDtos = new List<ClueDTO.ClueDto>();

        _mockClueRepository.Setup(x => x.GetByCaseIdAsync(caseId))
            .ReturnsAsync(emptyClues);
        
        _mockMapper.Setup(x => x.Map<IEnumerable<ClueDTO.ClueDto>>(emptyClues))
            .Returns(emptyDtos);

        // Act
        var result = await _clueService.GetByCaseIdAsync(caseId);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeEmpty();
    }

    [Fact]
    public async Task AddAsync_ValidClue_CallsRepositoryAdd()
    {
        // Arrange
        var clueDto = new ClueDTO.ClueDto
        {
            Title = "Nova Pista",
            Description = "Descrição da nova pista",
            Location = "Novo Local",
            DiscoveryDate = DateTime.Now,
            CaseId = 1
        };

        var clueEntity = new Clue
        {
            Title = "Nova Pista",
            Description = "Descrição da nova pista",
            Location = "Novo Local",
            CaseId = 1
        };

        var resultDto = new ClueDTO.ClueDto
        {
            Id = 1,
            Title = "Nova Pista",
            Description = "Descrição da nova pista",
            Location = "Novo Local",
            DiscoveryDate = DateTime.Now,
            CaseId = 1
        };

        _mockMapper.Setup(x => x.Map<Clue>(clueDto))
            .Returns(clueEntity);
        
        _mockClueRepository.Setup(x => x.AddAsync(clueEntity))
            .Returns(Task.CompletedTask);
        
        _mockMapper.Setup(x => x.Map<ClueDTO.ClueDto>(clueEntity))
            .Returns(resultDto);

        // Act
        var result = await _clueService.AddAsync(clueDto);

        // Assert
        result.Should().NotBeNull();
        result.Title.Should().Be(clueDto.Title);
        result.Description.Should().Be(clueDto.Description);
        result.Location.Should().Be(clueDto.Location);
        result.CaseId.Should().Be(clueDto.CaseId);
        
        _mockClueRepository.Verify(x => x.AddAsync(It.IsAny<Clue>()), Times.Once);
    }

    [Fact]
    public async Task UpdateAsync_ValidClue_CallsRepositoryUpdate()
    {
        // Arrange
        var clueDto = new ClueDTO.ClueDto
        {
            Id = 1,
            Title = "Pista Atualizada",
            Description = "Descrição atualizada",
            Location = "Local Atualizado",
            DiscoveryDate = DateTime.Now,
            CaseId = 1
        };

        var clueEntity = new Clue
        {
            Id = 1,
            Title = "Pista Atualizada",
            Description = "Descrição atualizada",
            Location = "Local Atualizado",
            CaseId = 1
        };

        _mockMapper.Setup(x => x.Map<Clue>(clueDto))
            .Returns(clueEntity);

        // Act
        await _clueService.UpdateAsync(clueDto);

        // Assert
        _mockClueRepository.Verify(x => x.UpdateAsync(clueEntity), Times.Once);
        _mockMapper.Verify(x => x.Map<Clue>(clueDto), Times.Once);
    }
}
