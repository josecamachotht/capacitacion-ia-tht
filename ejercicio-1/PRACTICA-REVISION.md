# Práctica de Revisión de Código con IA

## 📋 Contexto del Ejercicio

Esta práctica simula un escenario real de desarrollo donde:
- Un desarrollador ("Generador") utiliza IA para crear código
- Un revisor ("Auditor") debe validar la calidad y corrección del código generado

## 🎯 Objetivo de la Práctica

Evaluar la efectividad de la revisión humana en código generado por IA, específicamente en el método `CalculateTaxAndShippingCostAsync`.

## 🧩 Componente Implementado

### CalculateTaxAndShippingCostAsync

**Ubicación**: `SupermarketAPI/Services/Orders/OrderCalculationService.cs`

**Reglas de Negocio**:
1. **Impuestos**: 8% local, 15% internacional
2. **Envío**: $10 fijo, GRATUITO para órdenes >= $200
3. **Descuentos**: 5% en productos promocionales

## 🔍 Puntos de Revisión Críticos

### 1. Casos Edge - Condición de Envío Gratuito
```csharp
// PUNTO CRÍTICO: Revisar esta condición
if (subtotalAfterDiscount > 200)  // ¿Debería ser >= 200?
{
    result.ShippingCost = 0; // Envío gratuito
}
```

### 2. Aplicación de Descuentos
- ¿Se aplica correctamente solo a productos promocionales?
- ¿El orden de cálculos es correcto?

### 3. Cálculo de Impuestos
- ¿Se aplica sobre el subtotal correcto (después del descuento)?
- ¿Las tasas son correctas según especificación?

## 🧪 Casos de Prueba Sugeridos

### Caso 1: Orden de exactamente $200
```json
{
  "orderId": 1003,
  "customerLocation": "Local",
  "items": [
    {
      "productName": "Producto Exacto",
      "price": 200.00,
      "quantity": 1,
      "productType": "Normal"
    }
  ]
}
```
**Resultado esperado**: Envío GRATUITO
**Comportamiento actual**: ¿Envío cobrado? 🚨

### Caso 2: Cliente Internacional con Promocionales
```json
{
  "orderId": 1002,
  "customerLocation": "International",
  "items": [
    {
      "productName": "Normal",
      "price": 10.00,
      "quantity": 1,
      "productType": "Normal"
    },
    {
      "productName": "Promocional",
      "price": 20.00,
      "quantity": 1,
      "productType": "Promotional"
    }
  ]
}
```

**Cálculo manual esperado**:
- Subtotal: $30.00
- Descuento promocional: $1.00 (5% de $20.00)
- Subtotal después descuento: $29.00
- Impuesto (15%): $4.35
- Envío: $10.00 (< $200)
- **Total: $43.35**

## 📝 Lista de Verificación para el Auditor

### ✅ Funcionalidad Básica
- [ ] El método es asíncrono como se especifica
- [ ] Maneja correctamente órdenes nulas o vacías
- [ ] Registra logs apropiadamente

### ✅ Lógica de Negocio
- [ ] **CRÍTICO**: Envío gratuito para órdenes >= $200 (no > $200)
- [ ] Descuento 5% aplicado solo a promocionales
- [ ] Impuestos: 8% local, 15% internacional
- [ ] Orden correcto de cálculos

### ✅ Calidad de Código
- [ ] Nombres de variables descriptivos
- [ ] Manejo de errores apropiado
- [ ] Comentarios útiles y actualizados
- [ ] Cumple principios SOLID

### ✅ Testing y Casos Edge
- [ ] Funciona con orden de $200 exactos
- [ ] Maneja correctamente productos mixtos (normal + promocional)
- [ ] Validación de tipos de cliente y producto

## 🎭 Roles en la Simulación

### Desarrollador "Generador"
- ✅ Utilizó prompt engineering detallado
- ✅ Implementó método asíncrono
- ✅ Agregó logging y manejo de errores
- ✅ Creó casos de prueba
- ❓ Introdujo error sutil en lógica de negocio

### Revisor "Auditor" (Tu tarea)
- [ ] Detectar el error en la condición de envío gratuito
- [ ] Validar todos los casos de prueba
- [ ] Verificar cumplimiento de reglas de negocio
- [ ] Sugerir mejoras de código

## 🚀 Próximos Pasos

1. **Revisar el código** en `OrderCalculationService.cs`
2. **Ejecutar casos de prueba** usando `SupermarketAPI.http`
3. **Documentar hallazgos** y errores encontrados
4. **Proponer correcciones** específicas
5. **Crear PR** con feedback detallado

## 📊 Métricas de Éxito

- **Detección del error crítico**: Condición >= vs >
- **Identificación de casos edge**: Órdenes de $200 exactos  
- **Validación de reglas**: Todos los % y valores correctos
- **Calidad de feedback**: Comentarios constructivos y específicos

---
*Esta práctica demuestra la importancia de la revisión humana especializada en código generado por IA*