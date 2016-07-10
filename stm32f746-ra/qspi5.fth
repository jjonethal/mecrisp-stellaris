\ qspi5.fth


:gpio-mode-list qspi-4-send qd0 qd1 qd2 qd3 gcs qck
: qspi-4-send ( -- ) qd0 qd1 qd2 qd3 gcs qck 6 gpio-ports-output ;
: qspi-gpio-init ( -- ) qd0 gpio-output qd1 gpio