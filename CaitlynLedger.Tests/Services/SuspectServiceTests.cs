using AutoMapper;
using CaitlynsLedger.Application.Services;
using CaitlynsLedger.Domain.Entities;
using CaitlynsLedger.Domain.Interfaces;
using CaitlynsLedgerAPI.CaitlynsLedger.Application;
using FluentAssertions;
using Moq;

namespace CaitlynLedger.Tests.Services;

public class SuspectServiceTests
{
    private readonly Mock<ISuspectRepository> _mockSuspectRepository;
    private readonly Mock<IMapper> _mockMapper;
    private readonly SuspectService _suspectService;

    public SuspectServiceTests()
    {
        _mockSuspectRepository = new Mock<ISuspectRepository>();
        _mockMapper = new Mock<IMapper>();
        _suspectService = new SuspectService(_mockSuspectRepository.Object, _mockMapper.Object);
    }

    [Fact]
    public async Task GetByIdAsync_ExistingSuspect_ReturnsSuspect()
    {
        // Arrange
        var suspectId = 1;
        var expectedSuspect = new Suspect
        {
            Id = suspectId,
            Name = "Suspeito Teste",
            Description = "Descrição do suspeito",
            Status = "Investigando"
        };
        
        var expectedDto = new SuspectDTO.SuspectDto
        {
            Id = suspectId,
            Name = "Suspeito Teste",
            Description = "Descrição do suspeito",
            Status = "Investigando"
        };
        
        _mockSuspectRepository.Setup(x => x.GetByIdAsync(suspectId))
            .ReturnsAsync(expectedSuspect);
        
        _mockMapper.Setup(x => x.Map<SuspectDTO.SuspectDto>(expectedSuspect))
            .Returns(expectedDto);

        // Act
        var result = await _suspectService.GetByIdAsync(suspectId);

        // Assert
        result.Should().NotBeNull();
        result.Id.Should().Be(suspectId);
        result.Name.Should().Be("Suspeito Teste");
    }

    [Fact]
    public async Task GetByIdAsync_NonExistingSuspect_ReturnsNull()
    {
        // Arrange
        var suspectId = 999;
        _mockSuspectRepository.Setup(x => x.GetByIdAsync(suspectId))
            .ReturnsAsync((Suspect?)null);
        
        _mockMapper.Setup(x => x.Map<SuspectDTO.SuspectDto>(null))
            .Returns((SuspectDTO.SuspectDto?)null);

        // Act
        var result = await _suspectService.GetByIdAsync(suspectId);

        // Assert
        result.Should().BeNull();
    }
}
