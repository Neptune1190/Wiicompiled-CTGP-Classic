#include "runtime_product.h"

namespace RuntimeProduct {

const Descriptor& Active() noexcept {
    static constexpr Descriptor descriptor{
#ifdef MKW_CTGP_CLASSIC_PRODUCT
        Kind::CtgpClassic,
#else
        Kind::RetroRewind,
#endif
#ifdef MKW_CTGP_CLASSIC_PRODUCT
        "CTGP Classic",
#else
        "Retro Rewind",
#endif
    };
    return descriptor;
}

} // namespace RuntimeProduct
