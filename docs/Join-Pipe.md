---
external help file: Itertools.dll-Help.xml
Module Name: Itertools
online version:
schema: 2.0.0
---

# Join-Pipe

## SYNOPSIS
Joins items from the pipeline with values from another collection or script.

## SYNTAX

### script (Default)
```
Join-Pipe -InputObject <Object> [-ScriptBlock] <ScriptBlock> [<CommonParameters>]
```

### collection
```
Join-Pipe -InputObject <Object> [-ValuesRight] <Object[]> [<CommonParameters>]
```

## DESCRIPTION
Joins items from the pipeline with values from a collection or a script block.

If the script block parameter is used, the script will have the $_ automatic variable set to the current pipeline object and the value it yields will be used as the right value.

## EXAMPLES

### Example 1
```powershell
1..5 | Join-Pipe {$_ *$_}

Left Right
---- -----
   1     1
   2     4
   3     9
   4    16
   5    25
```

This example generates the squares of the numbers from 1 to 5.

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

### -ScriptBlock
A script block with access to the pipeline ($_) that will yield a value.

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

### -ValuesRight
A collection to join with the current pipe.

```yaml
Type: Object[]
Parameter Sets: collection
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

### Itertools.Zip

## NOTES

## RELATED LINKS
