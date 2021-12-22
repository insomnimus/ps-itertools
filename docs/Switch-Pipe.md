---
external help file: Itertools.dll-Help.xml
Module Name: Itertools
online version:
schema: 2.0.0
---

# Switch-Pipe

## SYNOPSIS
Alternates between the pipeline and a collection.

## SYNTAX

```
Switch-Pipe [-DiscardRest] -InputObject <Object> [-Values] <Object[]> [-Left <Int32>] [-Right <Int32>]
 [<CommonParameters>]
```

## DESCRIPTION
Alternates between the pipeline and a collection.

## EXAMPLES

### Example 1
```powershell
$left = "left 1", "left 2", "left 3"
$right = "right 1", "right 2", "right 3"
$left | Switch-Pipe $right
left 1
right 1
left 2
right 2
left 3
right 3
```

This example alternates between the left items and the right items.

## PARAMETERS

### -DiscardRest
Discard leftover items if left or right are drained before the other.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### -Left
How many items to take from the left pipe in each alternation.

```yaml
Type: Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Right
How many items to take from the right collection in each alternation.

```yaml
Type: Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Values
A collection to alternate with.

```yaml
Type: Object[]
Parameter Sets: (All)
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

### System.Object

## NOTES

## RELATED LINKS
