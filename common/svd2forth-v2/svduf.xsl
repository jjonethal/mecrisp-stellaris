<?xml version="1.0" encoding="utf-8"?>
<!-- svduf.xsl ARM CMSIS-SVD unfolder by kfoltman on freenode.irc ##tech40+  -->
<!-- This is free and unencumbered software released into the public domain. -->
<!-- For more information, please refer to <http://unlicense.org> -->
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:fn="http://www.w3.org/2005/xpath-functions" version="1.0">
<xsl:template match="node()">
    <xsl:choose>
      <xsl:when test="@derivedFrom">
        <xsl:variable name="var"><xsl:value-of select="@derivedFrom"/></xsl:variable>
        <xsl:copy>
            <xsl:copy-of select="name"/>
            <xsl:copy-of select="baseAddress"/>
            <xsl:copy-of select="/device/peripherals/peripheral[name=$var]/description"/>
            <xsl:copy-of select="/device/peripherals/peripheral[name=$var]/addressBlock"/>
            <xsl:copy-of select="interrupt"/>
            <xsl:copy-of select="/device/peripherals/peripheral[name=$var]/registers"/>
        </xsl:copy>
      </xsl:when>
      <xsl:otherwise>
        <xsl:copy>
            <xsl:copy-of select="@*"/>
            <xsl:apply-templates/>
        </xsl:copy>
      </xsl:otherwise>
    </xsl:choose>
</xsl:template>
</xsl:stylesheet>
