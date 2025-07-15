using AutoMapper;
using CaitlynsLedger.Application.Services;
using CaitlynsLedger.Domain.Entities;
using CaitlynsLedger.Domain.Interfaces;
using CaitlynsLedgerAPI.CaitlynsLedger.Application;
using FluentAssertions;
using Moq;

namespace CaitlynLedger.Tests.Services;

public class CaseServiceTests
{
    private readonly Mock<ICaseRepository> _mockCaseRepository;
    private readonly Mock<IMapper> _mockMapper;
    private readonly CaseService _caseService;

    public CaseServiceTests()
    {
        _mockCaseRepository = new Mock<ICaseRepository>();
        _mockMapper = new Mock<IMapper>();
        _caseService = new CaseService(_mockCaseRepository.Object, _mockMapper.Object);
    }

    [Fact]
    public async Task GetByIdAsync_ExistingCase_ReturnsCase()
    {
        // Arrange
        var caseId = 1;
        var expectedCase = new Case
        {
            Id = caseId,
            Name = "Caso Teste",
            Description = "Descrição do caso",
            Status = "Aberto"
        };
        
        var expectedDto = new CaseDTO.CaseDto
        {
            Id = caseId,
            Name = "Caso Teste",
            Description = "Descrição do caso",
            Status = "Aberto"
        };
        
        _mockCaseRepository.Setup(x => x.GetByIdAsync(caseId))
            .ReturnsAsync(expectedCase);
        
        _mockMapper.Setup(x => x.Map<CaseDTO.CaseDto>(expectedCase))
            .Returns(expectedDto);

        // Act
        var result = await _caseService.GetByIdAsync(caseId);

        // Assert
        result.Should().NotBeNull();
        result.Id.Should().Be(caseId);
        result.Name.Should().Be("Caso Teste");
    }

    [Fact]
    public async Task GetAllAsync_HasCases_ReturnsListOfCases()
    {
        // Arrange
        var cases = new List<Case>
        {
            new Case { Id = 1, Name = "Caso 1", Description = "Desc 1", Status = "Aberto" },
            new Case { Id = 2, Name = "Caso 2", Description = "Desc 2", Status = "Fechado" }
        };

        var caseDtos = new List<CaseDTO.CaseDto>
        {
            new CaseDTO.CaseDto { Id = 1, Name = "Caso 1", Description = "Desc 1", Status = "Aberto" },
            new CaseDTO.CaseDto { Id = 2, Name = "Caso 2", Description = "Desc 2", Status = "Fechado" }
        };

        _mockCaseRepository.Setup(x => x.GetAllAsync())
            .ReturnsAsync(cases);
        
        _mockMapper.Setup(x => x.Map<IEnumerable<CaseDTO.CaseDto>>(cases))
            .Returns(caseDtos);

        // Act
        var result = await _caseService.GetAllAsync();

        // Assert
        result.Should().NotBeNull();
        result.Should().HaveCount(2);
        result.First().Name.Should().Be("Caso 1");
    }
}
