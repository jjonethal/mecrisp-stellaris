<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<!--  SVD2GAS register extractor, Copyright Terry Porter 2017 "terry@tjporter.com.au" -->
<!--  Licensed under the GPL, see http://www.gnu.org/licenses/ -->

<xsl:output method ="xml" encoding="UTF-8" indent="yes"></xsl:output>

<xsl:template match="/device">
<xsl:comment> <xsl:text>  </xsl:text><xsl:value-of select="name"/> <xsl:text> </xsl:text></xsl:comment>
<xsl:comment> SVD2GAS register extractor, Copyright Terry Porter 2017 "terry@tjporter.com.au"</xsl:comment>
<xsl:comment> Licensed under the GPL, see http://www.gnu.org/licenses/</xsl:comment>
<xsl:text>

</xsl:text>
<xsl:for-each select="peripherals" >

<xsl:copy>
<xsl:text></xsl:text>
<xsl:copy-of select="peripheral/name"></xsl:copy-of>
</xsl:copy>
<xsl:text>  
</xsl:text>
</xsl:for-each> 
</xsl:template>
</xsl:stylesheet>
