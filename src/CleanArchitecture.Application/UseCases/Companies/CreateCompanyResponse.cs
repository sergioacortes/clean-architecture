﻿namespace CleanArchitecture.Orders.Application.UseCases.Companies;

public record CreateCompanyResponse(Guid Id, string TenantId, string TradeName);