<xsl:stylesheet version="1.0"
xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:output method="text"/>
  <xsl:template match="/device">
    <xsl:for-each select="peripherals/peripheral" >
      <xsl:variable name="device" select="name" />
      <xsl:value-of select="baseAddress" /> constant <xsl:value-of select="$device" /> 
      <xsl:text>  
      </xsl:text>

	<xsl:for-each select="registers/register" >
	   <xsl:text> </xsl:text>
	   <xsl:value-of select="$device"/>
	     <xsl:text> </xsl:text>
	      <xsl:value-of select="addressOffset" />
		<xsl:text> </xsl:text>
	         <xsl:text>+</xsl:text>
	           <xsl:text> </xsl:text>
	            <xsl:text>constant</xsl:text>
		     <xsl:text> </xsl:text>
	               <xsl:value-of select="$device"/><xsl:text>_</xsl:text><xsl:value-of select="name" />
	                
      <xsl:text>
      </xsl:text>
	</xsl:for-each>
	<xsl:text>  
	
     </xsl:text>



    </xsl:for-each> 
  

</xsl:template>
</xsl:stylesheet>
