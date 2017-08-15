<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<!-- SVD2GAS Equates and Bitfields Generator , Copyright Terry Porter 2017 "terry@tjporter.com.au" for arm-none-eabi-as -->
<!-- Licensed under the GPL, see http://www.gnu.org/licenses/</xsl:text> -->
<!-- <xsl:param name="parameters" select=" 'file:///parameters.txt' " /> -->

<!-- <xsl:param name="file" select="document('referenced.xml')"/> -->
<xsl:variable name="fileA" select="document('template.xml')"/>

<xsl:output method="text"/>
<!-- <xsl:output method="xml" encoding="UTF-8" indent="yes"/> -->

<xsl:template match="/device">
<xsl:text>@ arm-none-eabi-as equates file for </xsl:text>
<xsl:value-of select="name"/>
<xsl:text>
</xsl:text>
<xsl:text>@ SVD2GAS Equates Generator, Copyright Terry Porter 2017 "terry@tjporter.com.au" for arm-none-eabi-as </xsl:text>
<xsl:text>
</xsl:text>
<xsl:text>@ Takes a CMSIS-SVD file plus a hand edited config.xml file as input </xsl:text>
<xsl:text>
</xsl:text>
<xsl:text>@ Licensed under the GPL, see http://www.gnu.org/licenses/</xsl:text>
<xsl:text>

</xsl:text>

<xsl:text></xsl:text>
<xsl:for-each select="peripherals/peripheral">
<xsl:choose>
<xsl:when test=" name = $fileA/peripherals/name">
<xsl:text>
</xsl:text>
<xsl:variable name="device" select="name" />
<xsl:text>@=========================== </xsl:text>
<xsl:value-of select="$device"/>
<xsl:text> ===========================@</xsl:text>
<xsl:text>
</xsl:text>
<xsl:text>.equ </xsl:text>
<xsl:value-of select="$device" />
<xsl:text>_BASE, </xsl:text>
<xsl:value-of select="baseAddress" />
<xsl:text>
</xsl:text>


<xsl:for-each select="registers/register" >
<xsl:text>    </xsl:text><xsl:text>.equ </xsl:text>
<xsl:value-of select="$device"/><xsl:text>_</xsl:text><xsl:value-of select="name" />
<xsl:text>, </xsl:text>
<xsl:value-of select="$device"/>
<xsl:text>_BASE + </xsl:text>
<xsl:value-of select="addressOffset" />
<xsl:text>
</xsl:text>


<xsl:for-each select="fields/field">
<xsl:text>        </xsl:text><xsl:text>.equ </xsl:text>
<xsl:value-of select="$device"/>
<xsl:text>_</xsl:text>
<xsl:value-of select="name"/>
<xsl:choose>
<xsl:when test ="bitWidth = 1">
<xsl:text>, BIT</xsl:text>
<xsl:value-of select="bitOffset"/>
<xsl:text>   @ bitWidth </xsl:text>
<xsl:value-of select="bitWidth"></xsl:value-of>
</xsl:when>
</xsl:choose>

<xsl:choose>
<xsl:when test ="bitWidth > 1">
<xsl:text>_Shift, </xsl:text>
<xsl:value-of select="bitOffset"/>
<xsl:text>   @ bitWidth </xsl:text>
<xsl:value-of select="bitWidth"></xsl:value-of>
</xsl:when>
</xsl:choose>


<xsl:text> 
</xsl:text>
</xsl:for-each>
<xsl:text> 
</xsl:text>
</xsl:for-each>
</xsl:when>
</xsl:choose>
</xsl:for-each>
</xsl:template>
</xsl:stylesheet>