---
external help file: Itertools.dll-Help.xml
Module Name: Itertools
online version:
schema: 2.0.0
---

# Test-All

## SYNOPSIS
Tests if all items from the pipeline satisfy a predicate.

## SYNTAX

### script (Default)
```
Test-All -InputObject <Object> [-Predicate] <ScriptBlock> [<CommonParameters>]
```

### eq
```
Test-All -InputObject <Object> [-Value] <Object> [<CommonParameters>]
```

## DESCRIPTION
Tests if all items from the pipeline satisfy a predicate.

## EXAMPLES

### Example 1
```powershell
$evens = 0, 2, 4, 6, 8, 10
$evens | Test-All { $_ % 2 -eq 0 }
True

$ones = 1, 1, 1, 1, 1, 1
$ones | Test-All 1
True
```

<None>


## PARAMETERS

### -InputObject
The input object.

```yaml
Type: Object
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName, ByValue)
Accept wildcard characters: False
```

### -Predicate
A predicate that evaluates to a bool.

```yaml
Type: ScriptBlock
Parameter Sets: script
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Value
Test that all values from the pipeline are equal to this one.

```yaml
Type: Object
Parameter Sets: eq
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.Object

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS
